using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HealthcareSystem.DTOs.Payment_DTOS
{
    public class PaymentResponseDTO
    {
        public int Id {  get; set; }
        public int ClaimId { get; set;  }
        public decimal Amount { get; set; }
        public string Status {  get; set; }
        public string TransactionId { get; set; }
    }
}
