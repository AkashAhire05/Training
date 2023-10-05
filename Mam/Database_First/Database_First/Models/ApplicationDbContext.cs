using Microsoft.EntityFrameworkCore;

namespace Database_First.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<StudDF> StudDF1 { get; set; }
    }
}
