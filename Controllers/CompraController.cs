using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;
using System.ComponentModel;

namespace proy_caguamanta.Controllers
{
    public class CompraController : Controller
    {
        //Crear variable 
        public readonly ApplicationDbContext _context;

        //Crear constructor
        public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Metodos de accion
        public IActionResult Index() 
        {
            List<Compra> listaCompra = _context.Compras.ToList();
            return View(listaCompra);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Compra compra)
        {
            if (compra.Id == 0 && compra.EmpleadoId != 0 && compra.FechaCompra != null && compra.ProveedorId != 0 && compra.Importe != 0)
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", compra);
            }

        }

		[HttpGet]
		public IActionResult Editar(int id)
		{
			Compra estudiante = _context.Compras.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Compra compra)
		{
			if (compra.Id != 0 && compra.EmpleadoId != 0 && compra.FechaCompra != null && compra.ProveedorId != 0 && compra.Importe != 0)
			{
				_context.Compras.Update(compra);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", compra);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Compra estudiante = _context.Compras.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Compra compra)
		{
			_context.Compras.Remove(compra);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
