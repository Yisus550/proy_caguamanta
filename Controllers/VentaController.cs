using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class VentaController : Controller
	{
		private readonly ApplicationDbContext _context;

		private static Venta venta;
		private static List<ProductosList> _productos;
		private static List<SelectListItem> options;
		private static List<Venta> listaVenta;

		private int cantidad;
		private int idEmpleado;
		private int idCliente;
		private double precio;
		private double total;
		private double cambio;

		public VentaController(ApplicationDbContext context)
		{
			_context = context;
		}

		public ActionResult Index(double pago, int idCliente = 1, int idEmpleado = 1)
		{
			CargarProductos();
			CalcularTotal();
			CalcularCambio(pago);

			this.idEmpleado = idEmpleado;
			this.idCliente = idCliente;
			ViewBag.IdCliente = idCliente;
			ViewBag.IdEmpleado = idEmpleado;


			return View();
		}

		public IActionResult Listar()
		{
			listaVenta = _context.Ventas.ToList();
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
				venta.IdEmpleado = venta.IdEmpleado == 0 ? 1001 : 0;
				venta.IdCliente = venta.IdCliente == 0 ? 2001 : 0;
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
				_productos = new List<ProductosList>();
			}

			double subtotal = producto.Precio * cantidadProducto;
			ProductosList productoList = new ProductosList
			{
				Id = producto.Id,
				Nombre = producto.Nombre,
				Precio = producto.Precio,
				Cantidad = cantidadProducto,
				SubTotal = subtotal
			};

			_productos.Add(productoList);

			return RedirectToAction("Index");
		}

		public ActionResult LimpiarTabla()
		{
			_productos.Clear();
			return RedirectToAction("Index");
		}

		public ActionResult FinalizarVenta()
		{
			DetalleVentaController _detalleVenta = new DetalleVentaController(_context);

			CalcularTotal();
			venta = new Venta
			{
				FechaVenta = DateTime.Today,
				IdEmpleado = this.idEmpleado,
				IdCliente = this.idCliente,
				Importe = (decimal)total
			};

			Crear(venta);

			_detalleVenta.CrearMultiples(_productos);
			LimpiarTabla();
			return RedirectToAction("Index");
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
