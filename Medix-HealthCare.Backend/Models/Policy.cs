namespace HealthcareSystem.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal CoverageAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean IsActive { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
