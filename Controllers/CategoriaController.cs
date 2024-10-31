using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class CategoriaController : Controller
	{
		//Crear variable 
		public readonly ApplicationDbContext _context;

		//Crear constructor
		public CategoriaController(ApplicationDbContext context)
		{
			_context = context;
		}

		//Metodos de accion
		public IActionResult Index()
		{
			List<Categoria> listaCategoria = _context.Categorias.ToList();
			return View(listaCategoria);
		}
		[HttpGet]
		public IActionResult Crear()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Crear(Categoria categoria)
		{
			if (ModelState.IsValid)
			{
				_context.Categorias.Add(categoria);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", categoria);
			}

		}

		[HttpGet]
		public IActionResult Editar(int id)
		{
			Categoria estudiante = _context.Categorias.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Categoria categoria)
		{
			if (ModelState.IsValid)
			{
				_context.Categorias.Update(categoria);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", categoria);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Categoria estudiante = _context.Categorias.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Categoria categoria)
		{
			_context.Categorias.Remove(categoria);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
