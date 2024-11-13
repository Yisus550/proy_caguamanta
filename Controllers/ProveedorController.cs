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
			//validar apellido telefono correo empresa
			if (proveedor.IdProveedor == 0 && proveedor.Nombre != null && proveedor.Apellido != null && proveedor.Telefono != null && proveedor.Correo != null && proveedor.Empresa != null)
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
            Proveedor proveedor = _context.Proveedores.Find(id);
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Editar(Proveedor proveedor)
        {
            if (proveedor.IdProveedor == 0 && proveedor.Nombre != null && proveedor.Apellido != null && proveedor.Telefono != null && proveedor.Correo != null && proveedor.Empresa != null)
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
            Proveedor proveedor = _context.Proveedores.Find(id);
            return View(proveedor);
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
