using AutoMapper;
using AutoMapper.Configuration.Annotations;
using HealthcareSystem.Data;
using HealthcareSystem.DTOs.Claim_DTOs;
using HealthcareSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="ClaimOfficer")]
    public class ClaimOfficerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _service;
        private readonly IMapper _mapper;

        public ClaimOfficerController(ApplicationDbContext context, JwtService service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("pendingClaim")]
        public async Task<IActionResult> GetPendingClaim() {
            var pendingClaim = await _context.Claims.Where(c => c.Status == "pending").ToListAsync();
            if (pendingClaim == null)
                return NotFound("No Pending Claim Present");
            return Ok(_mapper.Map<List<ClaimResponseDTOs>>(pendingClaim));

        }

        [HttpPost("Approve/{id}")]
        public async Task<IActionResult> ApproveClaim(int id, ReviewClaimDTO dto) {
            var claim = await _context.Claims.Include(c=>c.Policy).FirstOrDefaultAsync(c => c.Id == id);
            if (claim == null)
                return NotFound("claim not found");
            if (claim.Status != "pending")
                return BadRequest("Claim already Processed");
            var policy = claim.Policy;
            if (policy == null)
                return BadRequest("Policy not found");
            if (!policy.IsActive || policy.EndDate < DateTime.Now)
            {
                return BadRequest("Policy is not active or expire");
            }
            else if (policy.CoverageAmount < claim.ClaimAmount)
            {
                claim.Status = "Rejected";
                claim.RejectedReason = "Claim Exceed Converage Amount";
            }
            else {
                if (dto.Decision == "Approved")
                {
                    claim.Status = "Approved";
                    claim.ApprovedAmount = dto.ApprovedAmount ?? claim.ClaimAmount;
                }
                else {
                    claim.Status = "Rejected";
                    claim.RejectedReason = dto.RejectionReason ?? "Regected by officer";
                }
            }

            claim.ReviewedBy = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            claim.ReviewedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "claim reveiwed succeddfully",
                status = claim.Status
            });
        }
        
    }
}
