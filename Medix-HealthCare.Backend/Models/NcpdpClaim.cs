namespace HealthcareSystem.Models
{
    public class NcpdpClaim
    {
            public string Bin { get; set; }
            public int CardholderId { get; set; }
            public string PolicyNumber { get; set; }
            public string Ndc { get; set; }
            public int Quantity { get; set; }
            public decimal Amount { get; set; }

    }
}
