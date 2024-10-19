using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Models;

namespace proy_caguamanta.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }
	}
}
