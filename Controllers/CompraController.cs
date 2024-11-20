using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class CompraController : Controller
	{
		//Crear variable 
		public readonly ApplicationDbContext _context;

		private static List<ProductosList> _productos;
		private static List<SelectListItem> options;
		private static List<Venta> listaVenta;

		private int cantidad;
		private int idEmpleado;
		private int idCliente;
		private double precio;
		private double total;
		private double cambio;

		//Crear constructor
		public CompraController(ApplicationDbContext context)
		{
			_context = context;
		}

		public ActionResult Index(double pago, int idCliente = 1001, int idEmpleado = 2001)
		{
			CargarDatos(pago, idCliente, idEmpleado);
			ViewBag.IdVenta = _context.Ventas.OrderBy(v => v.Id).Last().Id + 1;
			ViewBag.IdCliente = this.idCliente;
			ViewBag.IdEmpleado = this.idEmpleado;
			return View();
		}

		//Metodos de accion
		public IActionResult Listar()
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
			if (ModelState.IsValid)
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
			if (ModelState.IsValid)
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

		private void CargarDatos(double pago, int idCliente = 1, int idEmpleado = 1)
		{
			CargarProductos();
			CalcularTotal();
			CalcularCambio(pago);
			// Incrementar el 'Id' de la ultima venta para obtener el actual. No funciona con '++', se le tiene que agregar '+ 1'
			this.idEmpleado = idEmpleado;
			this.idCliente = idCliente;
		}

		private void CargarProductos()
		{
			options = _context.Productos.Select(p => new SelectListItem
			{
				Text = p.Nombre,
				Value = p.Id.ToString()
			}).ToList();

			ViewBag.SelectListProductos = options;
			ViewBag.Productos = _productos;
		}

		private void CalcularTotal()
		{
			total = _productos != null ? _productos.Sum(p => p.SubTotal) : 0;
			ViewBag.Total = total;
		}

		private void CalcularCambio(double pago)
		{
			cambio = pago <= 0 ? 0 : pago - total;

			ViewBag.Pago = pago;
			ViewBag.Cambio = cambio >= 0 ? cambio : 0;
		}
	}
}
