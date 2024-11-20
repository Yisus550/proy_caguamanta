using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class ProductoController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Producto> listaProducto = _context.Productos.ToList();
            return View(listaProducto);
        }
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Producto producto)
		{
			//validar
			if (producto.Id == 0 && producto.Nombre != null && producto.Descripcion != null && producto.Precio != null && producto.Cantidad != null && producto.CategoriaId != null)
			{
				// agregar, guardar y redireccionar
				_context.Productos.Add(producto);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", producto);
			}

		}

		[HttpGet]
		public IActionResult Editar(int id)
		{
			Producto estudiante = _context.Productos.Find(id);
			return View(estudiante);
		}


		[HttpPost]
		public IActionResult Editar(Producto producto)
		{
			if (producto.Id != 0 && producto.Nombre != null && producto.Descripcion != null && producto.Precio != null && producto.Cantidad != null && producto.CategoriaId != null)
			{
				_context.Productos.Update(producto);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", producto);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Producto estudiante = _context.Productos.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Producto producto)
		{
			_context.Productos.Remove(producto);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
