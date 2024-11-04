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
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Proveedor proveedor)
		{
			//validar
			if (ModelState.IsValid)
			{
				// agregar, guardar y redireccionar
				_context.Proveedores.Add(proveedor);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", proveedor);
			}
		}

		[HttpGet]
		public IActionResult Editar(int id)
		{
			Proveedor estudiante = _context.Proveedores.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Proveedor proveedor)
		{
			if (ModelState.IsValid)
			{
				_context.Proveedores.Update(proveedor);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", proveedor);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Proveedor estudiante = _context.Proveedores.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Proveedor proveedor)
		{
			_context.Proveedores.Remove(proveedor);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
