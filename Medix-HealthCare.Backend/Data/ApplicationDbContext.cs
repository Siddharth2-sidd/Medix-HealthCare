using HealthcareSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace HealthcareSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Policy> Policies { get; set;  }
        public DbSet<Claims> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
