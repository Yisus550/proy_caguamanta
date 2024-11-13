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

		public ActionResult Index()
		{
            List<SelectListItem> options = _context.Productos.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).ToList();

            ViewBag.SelectListProductos = options;
            ViewBag.Productos = _productos;
            ViewBag.Total = _productos != null ? _productos.Sum(p => (double)p.GetType().GetProperty("SubTotal").GetValue(p)) : 0;
            ViewBag.Empleado = GetEmpleadoSelectList();
            ViewBag.Cliente = GetClientesSelectList();
            //List<Venta> listaVenta = _context.Ventas.ToList();
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
            ViewBag.Empleado = GetEmpleadoSelectList();
            ViewBag.Cliente = GetClientesSelectList();
            return View();
		}
		[HttpPost]
		public IActionResult Crear(Venta venta)
		{
			//validar
			if (venta.Id == 0 && venta.FechaVenta != null && venta.IdEmpleado != null && venta.IdCliente != null && venta.Importe != null)
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
        private List<SelectListItem> GetClientesSelectList()
        {
            return _context.Clientes.Select(d => new SelectListItem
            {
                Text = d.Nombre,
                Value = d.Id.ToString(),
                Selected = false
            }).ToList();
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
                SubTotal = producto.Precio * cantidadProducto
            });

            return RedirectToAction("Index");
        }

        public ActionResult LimpiarTabla()
        {
            _productos = new List<Object>();
            return RedirectToAction("Index");
        }
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
			if (venta.Id != 0 && venta.FechaVenta != null && venta.IdEmpleado != null && venta.IdCliente != null && venta.Importe != null)
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
			return View(venta);
		}

		[HttpPost]
		public IActionResult Eliminar(Venta venta)
		{
			_context.Ventas.Remove(venta);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
