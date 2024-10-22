using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class VentaController : Controller
	{
		public readonly ApplicationDbContext _context;

		public VentaController(ApplicationDbContext context)
		{
			_context = context;
		}

		public ActionResult Index() 
		{
			List<Venta> listaVenta = _context.Ventas.ToList();
		return View(listaVenta);
		}
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Venta venta)
		{
			//validar
			if (ModelState.IsValid)
			{
				// agregar, guardar y redireccionar
				_context.Ventas.Add(venta);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", venta);
			}
		}
	}
}
