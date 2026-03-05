using AutoMapper;
using HealthcareSystem.Data;
using HealthcareSystem.DTOs.User_DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Models;
using HealthcareSystem.Services;
using Microsoft.AspNetCore.Authorization;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _service;
        private readonly IMapper _mapper;

        public AuthController(ApplicationDbContext context, JwtService service, IMapper mapper) {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        //Register
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto) {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email already exit");
            
            var user = _mapper.Map<User>(dto);
            user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.HashedPassword);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<UserResponseDTOs>(user);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO dto) {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Email == dto.Email);
            if (user == null) {
                return Unauthorized("Invalid Email");
            }
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.HashedPassword)) {
                return Unauthorized("Invalid Password");
            }

            var token = _service.GenrateToken(user);
            return Ok(new
            {
                token,
                role = user.Role
            });
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetUser() {
            var users = await _context.Users.ToListAsync();
            var response = _mapper.Map<List<UserResponseDTOs>>(users);
            return Ok(response);
        }
    }
}
