using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Models;

namespace proy_caguamanta.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Compra> Compras { get; set; }
		public DbSet<DetalleCompra> DetalleCompras { get; set; }
		public DbSet<DetalleVenta> DetalleVentas { get; set; }
		public DbSet<Empleado> Empleados { get; set; }
		public DbSet<Material> Materiales { get; set; }
		public DbSet<Producto> Productos { get; set; }
		public DbSet<Proveedor> Proveedores { get; set; }
		public DbSet<Puesto> Puestos { get; set; }
		public DbSet<Venta> Ventas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            // Configuración de la relación uno a muchos
            
			// puestos
            modelBuilder.Entity<Empleado>()
				.HasOne(a => a.Puesto)
				.WithMany(e => e.Empleado)
				.HasForeignKey(a => a.IdPuesto);

			// categorias
			modelBuilder.Entity<Categoria>()
				.HasMany(c => c.Producto)
				.WithOne(p => p.Categoria)
				.HasForeignKey(c => c.IdCategoria);

			modelBuilder.Entity<Categoria>()
				.HasMany(c => c.Material)
				.WithOne(m => m.Categoria)
				.HasForeignKey(c => c.IdCategoria);
			// detalle de compra
			modelBuilder.Entity<Material>()
				.HasMany(m => m.DetalleCompra)
				.WithOne(d => d.Material)
				.HasForeignKey(m => m.IdProducto);
			// detalle de venta
			modelBuilder.Entity<Producto>()
				.HasMany(m => m.DetalleVentas)
				.WithOne(d => d.Producto)
				.HasForeignKey(m => m.IdProducto);
			// venta
			modelBuilder.Entity<Empleado>()
				.HasMany(m => m.Venta)
				.WithOne(d => d.Empleado)
				.HasForeignKey(m => m.IdEmpleado);

            modelBuilder.Entity<Cliente>()
              .HasMany(m => m.Venta)
              .WithOne(d => d.Cliente)
              .HasForeignKey(m => m.IdCliente);
            // compra
            modelBuilder.Entity<Empleado>()
                .HasMany(m => m.Compra)
                .WithOne(d => d.Empleado)
                .HasForeignKey(m => m.IdEmpleado);

            modelBuilder.Entity<Proveedor>()
              .HasMany(m => m.Compra)
              .WithOne(d => d.Proveedor)
              .HasForeignKey(m => m.IdProveedor);


        }
    }
}
