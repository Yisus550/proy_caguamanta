using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class VentaController : Controller
	{
		//Crear variable 
		public readonly ApplicationDbContext _context;

		//Crear constructor
		public VentaController(ApplicationDbContext context)
		{
			_context = context;
		}

		//Metodos de accion
		public IActionResult Index()
		{
			List<Venta> listaventa = _context.Ventas.ToList();
			return View(listaventa);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			ViewBag.Empleado = GetEmpleadoSelectList();
			ViewBag.Cliente = GetClienteSelectList();
			return View();
		}

		[HttpPost]
		public IActionResult Crear(Venta venta)
		{
			if (venta.Id == 0 && venta.IdEmpleado != 0 && venta.FechaVenta != null && venta.IdCliente != 0 && venta.Importe != 0)
			{
				_context.Ventas.Add(venta);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Empleado = GetEmpleadoSelectList();
				ViewBag.Cliente = GetClienteSelectList();
				return View("Crear", venta);
			}

		}
		// metodo para mandar los empleados 
		private List<SelectListItem> GetEmpleadoSelectList()
		{
			return _context.Empleados.Select(d => new SelectListItem
			{
				Text = d.Nombre,
				Value = d.Id.ToString(),
				Selected = false
			}).ToList();
		}
		// metodo para mandar los clientes 
		private List<SelectListItem> GetClienteSelectList()
		{
			return _context.Clientes.Select(d => new SelectListItem
			{
				Text = d.Nombre, // valor mostrado
				Value = d.Id.ToString(), // valor tomado
				Selected = false
			}).ToList();
		}

		[HttpGet]
		public IActionResult Editar(int id)
		{
			Venta venta = _context.Ventas.Find(id);
			return View(venta);
		}

		[HttpPost]
		public IActionResult Editar(Venta venta)
		{
			if (venta.Id != 0 && venta.IdEmpleado != null && venta.FechaVenta != null && venta.IdCliente != null && venta.Importe != null)
			{
				_context.Ventas.Update(venta);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", venta);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Venta venta = _context.Ventas.Find(id);
			if(venta == null)
			{
            return View(venta);
			}
			_context.Ventas.Remove(venta);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
