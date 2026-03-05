namespace HealthcareSystem.DTOs.Policy_DTOs
{
    public class ResponsePolicyDTOs
    {
        public int Id { get; set; } 
        public string PolicyNumber { get; set; }
        public decimal CoverageAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
