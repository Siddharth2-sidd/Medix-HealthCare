namespace HealthcareSystem.Models
{
    public class Claims
    {
        public int Id { get; set; } 
        public string ClaimNumber { get; set; }
        public int PolicyId { get; set; }
        public int PharmacyId { get; set; }
        public string DrugCode { get; set; }
        public int Quantity { get; set; }
        public decimal ClaimAmount { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string Status { get; set; }
        public string NcpdpRawData { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public Policy Policy { get; set; }

        public string? RejectedReason { get; set; }
    }
}
