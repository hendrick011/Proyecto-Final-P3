using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class BreadDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public BreadDbContext(DbContextOptions<BreadDbContext> options)
            : base(options)
        { }
    }
}
