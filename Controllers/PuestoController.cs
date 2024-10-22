using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class PuestoController : Controller
	{
		public readonly ApplicationDbContext _context;

		public PuestoController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<Puesto> listPuesto = _context.Puestos.ToList();
			return View(listPuesto);
		}
	}
}
