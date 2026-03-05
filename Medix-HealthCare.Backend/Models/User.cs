using System.ComponentModel.DataAnnotations;

namespace HealthcareSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; } 
        public required string Email { get; set; }  
        public required string HashedPassword { get; set; }
        public required string Role { get; set; }
        public required string Phone_Number { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
