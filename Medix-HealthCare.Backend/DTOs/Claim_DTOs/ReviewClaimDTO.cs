namespace HealthcareSystem.DTOs.Claim_DTOs
{
    public class ReviewClaimDTO
    {
        public string Decision {  get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string RejectionReason { get; set; }
    }
}
