namespace HealthcareSystem.Models
{
    public class Payment
    {
        public int Id { get; set; } 
        public int ClaimId {  get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
    }
}
