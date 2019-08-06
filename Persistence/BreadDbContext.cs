using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistence
{
    public class BreadDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }

        public BreadDbContext(DbContextOptions<BreadDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         

            modelBuilder.Entity<Compra>()
                .HasKey(s => new { s.IdCompra });

            modelBuilder.Entity<Producto>()
                .HasKey(p => new { p.IdProducto });

            modelBuilder.Entity<Proveedor>()
                .HasKey(b => new { b.IdProveedor });

            modelBuilder.Entity<Empleado>()
               .HasKey(b => new { b.IdEmpleado });
        }
    }
}
