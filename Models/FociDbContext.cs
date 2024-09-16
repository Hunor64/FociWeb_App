using Microsoft.EntityFrameworkCore;

namespace FociWeb_App.Models
{
    public class FociDbContext : DbContext
    {
        public FociDbContext(DbContextOptions<FociDbContext> options) : base(options)
        {

        }
        public DbSet<Meccs> Meccsek { get; set; }
    }
}
