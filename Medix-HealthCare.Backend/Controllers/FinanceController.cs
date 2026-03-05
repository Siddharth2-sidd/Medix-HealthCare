using AutoMapper;
using HealthcareSystem.Data;
using HealthcareSystem.DTOs.Claim_DTOs;
using HealthcareSystem.DTOs.Payment_DTOS;
using HealthcareSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthcareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Finance")]
    public class FinanceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public FinanceController(IMapper mapper, ApplicationDbContext context) {
            _mapper = mapper;
            _context = context; 
        }
        [HttpGet("ApprovedClaim")]
        public async Task<IActionResult> GetApprovedClaim() {
            var approvedClaim = await _context.Claims.Where(c => c.Status == "Approved").ToListAsync();
            if (approvedClaim == null) {
                return BadRequest("No Approved Claim present");
            }
            return Ok(_mapper.Map<List<ClaimResponseDTOs>>(approvedClaim));

        }
        [HttpPost("pay/{claimId}")]
        public async Task<IActionResult> ProcessPayment(int claimId) {
            var claim = await _context.Claims.FirstOrDefaultAsync(c => c.Id == claimId);
            if (claim == null) {
                return BadRequest("Claim not found");
            }
            var paymentClaim = await _context.Payments.FirstOrDefaultAsync(p => p.ClaimId == claimId);
            if (paymentClaim != null)
                return BadRequest("Claim already paid");

            if (claim.Status != "Approved") {
                return BadRequest("Claim is not Approved");
            }
            
            var payment = new Payment
            {
                ClaimId = claimId,
                PaymentDate = DateTime.Now,
                Amount = claim.ApprovedAmount ?? claim.ClaimAmount,
                Status = "Paid",
                TransactionId = "TXN-" + Guid.NewGuid().ToString().Substring(0, 8)
            };
            _context.Payments.Add(payment);
            claim.Status = "Paid";
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<PaymentResponseDTO>(paymentClaim));
        }
        
    }
}