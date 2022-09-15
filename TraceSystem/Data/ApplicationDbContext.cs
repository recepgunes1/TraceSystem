using Microsoft.EntityFrameworkCore;
using TraceSystem.Models;

namespace TraceSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
