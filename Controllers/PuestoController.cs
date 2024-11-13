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

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Puesto puesto = _context.Puestos.Find(id);
            return View(puesto);
        }

        [HttpPost]
        public IActionResult Editar(Puesto puesto)
        {
            if (puesto.Id == 0 && puesto.Nombre != null && puesto.Sueldo > 0)
            {
                _context.Puestos.Update(puesto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Editar", puesto);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Puesto puesto = _context.Puestos.Find(id);
            return View(puesto);
        }

        [HttpPost]
        public IActionResult Eliminar(Puesto puesto)
        {
            _context.Puestos.Remove(puesto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
