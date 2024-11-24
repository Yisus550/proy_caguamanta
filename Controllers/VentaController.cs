using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class VentaController : Controller
	{
		private readonly ApplicationDbContext _context;

		private static List<ProductosList> _productos;
		private static List<SelectListItem> options;
		private static List<Venta> listaVenta;
		private static List<SelectListItem> EmpleadoC;
		private static List<SelectListItem> ClienteC;

		private static int cantidad;
		private static int idEmpleadoRecover;
		private static int idClienteRecover;
		private static double precio;
		private static double total;
		private static double cambio;


		public VentaController(ApplicationDbContext context)
		{
			_context = context;
		}

		private void CargarEmpleado()
		{
			EmpleadoC = _context.Empleados.Select(e => new SelectListItem
			{
				Text = e.Nombre,
				Value = e.Id.ToString()
			}).ToList();

			ViewBag.SelectEmpleado = EmpleadoC;
		}
		private void CargarCliente()
		{
			ClienteC = _context.Clientes.Select(e => new SelectListItem
			{
				Text = e.Nombre,
				Value = e.Id.ToString()
			}).ToList();

			ViewBag.SelectCliente = ClienteC;
		}
		/// <summary>
		/// Metodo que se encarga de cargar la vista principal de la venta.
		/// </summary>
		/// <param name="pago">Cantidad de dinero que el cliente paga</param>
		/// <param name="idCliente">Id del cliente que realiza la compra, 1001 por defecto</param>
		/// <param name="idEmpleado">Id del empleado que realiza la venta, 2001 por defecto</param>
		/// <returns>Retorna la vista principal de la venta.</returns>
		public ActionResult Index(double pago = 0, int idCliente = 1, int idEmpleado = 1)
		{
			CargarDatos(pago, idCliente, idEmpleado);
			if (_context.Ventas.Count() == 0)
			{
				ViewBag.IdVenta = 1;
			}
			else
			{
				ViewBag.IdVenta = _context.Ventas.OrderBy(v => v.Id).Last().Id + 1;// toma el valor de la ultima venta y le suma 1 
			}
			
			ViewBag.IdEmpleado = idEmpleadoRecover;
			ViewBag.IdCliente = idClienteRecover;
			
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


		/// <summary>
		/// Método que se encarga de crear una venta. Valida el modelo y redirecciona a la vista principal de ventas.
		/// </summary>
		/// <param name="venta">Objeto de venta con el contenido a registrar</param>
		/// <returns>Redirecciona a la vista principal <see cref="Index"/></returns>
		[HttpPost]
		public IActionResult Crear(Venta venta)
		{
			//validar
			if (!ModelState.IsValid)
				return View("Crear", venta);

			// agregar, guardar y redireccionar
			venta.EmpleadoId = idEmpleadoRecover;
			venta.ClienteId = idClienteRecover;
			_context.Ventas.Add(venta);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		/// <summary>
		/// Método que se encarga de crear una venta al finalizar la compra. A diferencia del método Crear, este no valida el modelo ni redirecciona a ningúna vista.
		/// </summary>
		/// <param name="venta">Objeto de venta con el contenido a registrar</param>
		public void CrearAlFinalizar(Venta venta)
		{
			venta.EmpleadoId = idEmpleadoRecover;
			venta.ClienteId = idClienteRecover;
			_context.Ventas.Add(venta);
			_context.SaveChanges();
		}

		[HttpPost]
		public ActionResult AgregarProducto(int productoId, int cantidadProducto)
		{
			Producto producto = _context.Productos.Find(productoId);

			if (_productos == null)
				_productos = new List<ProductosList>();

			ProductosList productoList = new ProductosList
			{
				Id = producto.Id,
				Nombre = producto.Nombre,
				Precio = producto.Precio,
				Cantidad = cantidadProducto,
				SubTotal = producto.Precio * cantidadProducto
			};

			_productos.Add(productoList);
			return RedirectToAction("Index");
		}

		public ActionResult LimpiarTabla()
		{
			_productos.Clear();
			return RedirectToAction("Index");
		}

		public ActionResult FinalizarVenta(int idEmpleado, int idCliente)
		{
			DetalleVentaController _detalleVenta = new DetalleVentaController(_context);

			CalcularTotal();
			Venta venta = new Venta
			{
				FechaVenta = DateTime.Today,
				EmpleadoId = idEmpleado,
				ClienteId = idCliente,
				Importe = (decimal)total
			};

			CrearAlFinalizar(venta);
			_detalleVenta.CrearMultiples(_productos);
			_productos.Clear();
			return RedirectToAction("Index");
		}

		private void CargarDatos(double pago, int idCliente, int idEmpleado)
		{
			CargarProductos();
			CargarCliente();
			CargarEmpleado();
			CalcularTotal();
			CalcularCambio(pago);
			idEmpleadoRecover = idEmpleado;
			idClienteRecover = idCliente;
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
