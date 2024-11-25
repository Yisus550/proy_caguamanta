using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class MaterialController : Controller
	{
		public readonly ApplicationDbContext _context;

		public MaterialController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<Material> listMaterial = _context.Materiales.ToList();
			return View(listMaterial);
		}
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Material material)
		{
			//validar
			if (material.Id == 0 && material.Nombre != null && material.ProveedorId != null && material.Cantidad != null && material.Costo != null && material.CategoriaId != null)
			{
				// agregar, guardar y redireccionar
				_context.Materiales.Add(material);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", material);
			}
		}
		[HttpGet]
		public IActionResult Editar(int id)
		{
			Material estudiante = _context.Materiales.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Material material)
		{
			if (material.Id != 0 && material.Nombre != null && material.ProveedorId != null && material.Cantidad != null && material.Costo != null && material.CategoriaId != null)
			{
				_context.Materiales.Update(material);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", material);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Material estudiante = _context.Materiales.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Material material)
		{
			_context.Materiales.Remove(material);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
