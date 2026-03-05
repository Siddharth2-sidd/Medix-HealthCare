namespace HealthcareSystem.DTOs.Claim_DTOs
{
    public class ClaimResponseDTOs
    {
        public int Id { get; set; }
        public string ClaimNumber { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}
