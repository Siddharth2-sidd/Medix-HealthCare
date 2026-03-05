namespace HealthcareSystem.DTOs.Policy_DTOs
{
    public class CreatepolicyDTOs
    {
        public string PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal CoverageAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
