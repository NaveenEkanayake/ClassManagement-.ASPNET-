using Microsoft.EntityFrameworkCore;
using Studentportal.Models.Entities;

namespace Studentportal.Data
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; }
    }
}
