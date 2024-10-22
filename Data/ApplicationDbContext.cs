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
	}
}
