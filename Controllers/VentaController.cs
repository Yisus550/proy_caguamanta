using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class VentaController : Controller
	{
		public readonly ApplicationDbContext _context;
		private static List<Object> _productos;

		private static int cantidad;
		private static double precio;

		public VentaController(ApplicationDbContext context)
		{
			_context = context;
		}

		public ActionResult Index(double pago)
		{
			CargarProductos();
			CalcularTotal();
			CalcularCambio(pago);

			return View();
		}

		public IActionResult Listar()
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

		[HttpPost]
		public ActionResult AgregarProducto(int productoId, int cantidadProducto)
		{
			Producto producto = _context.Productos.Find(productoId);

			if (_productos == null)
			{
				_productos = new List<Object>();
			}
			_productos.Add(new
			{
				producto.Id,
				producto.Nombre,
				producto.Precio,
				cantidadProducto,
				SubTotal = producto.Precio * cantidadProducto,
			});

			return RedirectToAction("Index");
		}

		public ActionResult LimpiarTabla()
		{
			_productos = new List<Object>();
			return RedirectToAction("Index");
		}

		private void CargarProductos()
		{
			List<SelectListItem> options = _context.Productos.Select(p => new SelectListItem
			{
				Text = p.Nombre,
				Value = p.Id.ToString()
			}).ToList();

			ViewBag.SelectListProductos = options;
			ViewBag.Productos = _productos;
		}

		private void CalcularTotal()
		{
			double total = _productos != null ? _productos.Sum(p => (double)p.GetType().GetProperty("SubTotal").GetValue(p)) : 0;
			ViewBag.Total = total;
		}

		private void CalcularCambio(double pago)
		{
			double total = _productos != null ? _productos.Sum(p => (double)p.GetType().GetProperty("SubTotal").GetValue(p)) : 0;
			double cambio = pago <= 0 ? 0 : pago - total;

			ViewBag.Pago = pago;
			ViewBag.Cambio = cambio >= 0 ? cambio : 0;
		}
	}
}
