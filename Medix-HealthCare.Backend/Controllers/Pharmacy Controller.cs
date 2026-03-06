using HealthcareSystem.Data;
using HealthcareSystem.NCPDP;
using HealthcareSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HealthcareSystem.Models;
using AutoMapper.Configuration.Annotations;
using HealthcareSystem.DTOs.Claim_DTOs;
using AutoMapper;
using Medix_HealthCare.Backend.DTOs.Claim_DTOs;


namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Pharmacy")]
    public class Pharmacy_Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;

        public Pharmacy_Controller(ApplicationDbContext context, JwtService jwtService, IMapper mapper) 
        {
            _context = context;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitNCPDP([FromBody] NcpdpRequestDTO dto) {
            if (string.IsNullOrEmpty(dto.RawData))
                return BadRequest("NCPDP data require");
            var parsed = NcpdpParser.Parser(dto.RawData);

            // Valid Policy
            var policy = await _context.Policies.FirstOrDefaultAsync(p => p.PolicyNumber ==  parsed.PolicyNumber);
            if (policy == null) {
                return BadRequest("Invalid Policy");
            }

            if (!policy.IsActive || policy.EndDate < DateTime.Now)
                return BadRequest("Policy in Active or Expired");

            // Get pharmacyId from JWT
            int pharmacyId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier).Value);

            // Create claim
            var claim = new Claims
            {
                ClaimNumber = "CLM" + Guid.NewGuid().ToString().Substring(0, 8),
                PolicyId = policy.Id,
                PharmacyId = pharmacyId,
                DrugCode = parsed.Ndc,
                Quantity = parsed.Quantity,
                ClaimAmount = parsed.Amount,
                Status = "pending",
                NcpdpRawData = dto.RawData,
                SubmittedDate = DateTime.Now
            };

            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            return Ok(new {
                message = "Claim Submitted SuccessFully",
                claimNumber = claim.ClaimNumber,
                status = claim.Status
            });

        }

        [HttpGet("claims")]
        public async Task<IActionResult> GetMyClaims() {
            int pharmacyId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var claims = await _context.Claims.Where(c => c.PharmacyId == pharmacyId).ToListAsync();
            return Ok(_mapper.Map<List<ClaimResponseDTOs>>(claims));
        }

    }
}
