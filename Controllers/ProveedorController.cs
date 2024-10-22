using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class ProveedorController : Controller
	{
		public readonly ApplicationDbContext _context;

		public ProveedorController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{ 
			List<Proveedor> listaProveedor = _context.Proveedores.ToList();
		return View(listaProveedor);
		}
	}
}
