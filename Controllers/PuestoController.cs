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
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Puesto puesto)
		{
			//validar ModelState.IsValid
			if (puesto.Id == 0 && puesto.Nombre != null && puesto.Sueldo != null)
			{
				// agregar, guardar y redireccionar
				_context.Puestos.Add(puesto);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", puesto);
			}
		}
	}
}
