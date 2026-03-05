using AutoMapper;
using HealthcareSystem.Data;
using HealthcareSystem.DTOs.Claim_DTOs;
using HealthcareSystem.DTOs.Policy_DTOs;
using HealthcareSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AdminController(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost("policy")]
        public async Task<IActionResult> CreatePolicy(CreatepolicyDTOs dto) {
            var createPolicy = await _context.Policies.AddAsync(_mapper.Map<Policy>(dto));
            await _context.SaveChangesAsync();
            return Ok("Policy Created");
        }
        [HttpGet("policy")]
        public async Task<IActionResult> GetPolicy() {
            var policies = await _context.Policies.ToListAsync();
            return Ok(_mapper.Map<List<ResponsePolicyDTOs>>(policies));
        }

        [HttpPut("policy/customer/{customerId}")]
        public async Task<IActionResult> UpdatePolicy(int customerId, UpdatepolicyDTOs dto) {
            var customer = await _context.Policies.FirstOrDefaultAsync(p => p.CustomerId == customerId);
            if (customer == null) {
                return BadRequest("Customer not found");
            }
            _mapper.Map(dto, customer);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<ResponsePolicyDTOs>(customer));
        }

        [HttpPut("policy/deactive/{id}")]
        public async Task<IActionResult> DeactivePolicy(int id) {
            var policy = await _context.Policies.FirstOrDefaultAsync(p => p.Id == id);
            if (policy == null) {
                return BadRequest("Policy not found");
            }
            policy.IsActive = false;
            await _context.SaveChangesAsync();
            return Ok("Policy deactive successfully");
        }

        [HttpGet("claims")]
        public async Task<IActionResult> ViewClaim() { 
            var claims = await _context.Claims.ToListAsync();
            return Ok(_mapper.Map<List<ClaimResponseDTOs>>(claims));
        }

        [HttpGet("claims/{status}")]
        public async Task<IActionResult> ClaimStatus(string status) {
            var claimStatus = await _context.Claims.Where(c => c.Status == status).ToListAsync();
            if (claimStatus == null) { 
                return NotFound("No claim Found");
            }

            return Ok(_mapper.Map<List<ClaimResponseDTOs>>(claimStatus));
        }

    }
}
