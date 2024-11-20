using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class DetalleVentaController : Controller
	{
		//Crear variable
		public readonly ApplicationDbContext _context;
		List<DetalleVenta> detalleVentas;

		//Crear constructor
		public DetalleVentaController(ApplicationDbContext context)
		{
			_context = context;
		}

		//Metodos de accion
		public IActionResult Index()
		{
			List<DetalleVenta> listaDetalleVenta = _context.DetalleVentas.ToList();
			return View(listaDetalleVenta);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Crear(DetalleVenta detalleVenta)
		{
			if (ModelState.IsValid)
			{
				_context.DetalleVentas.Add(detalleVenta);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", detalleVenta);
			}

		}
        [HttpGet]
        public IActionResult CrearMulti()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CrearMulti(DetalleVenta detalleVenta)
        {
            //Creamos las varibales 
            string idVenta = Request.Form["IdVenta"];
            string idProducto = Request.Form["IdProducto"];
            string precio = Request.Form["PrecioUnidad"];
            string cantidad = Request.Form["Cantidad"];
            string importe = Request.Form["Importe"];

            //Creamos lista de los elementos de la variable 
            var listaIdVenta = idVenta.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaIdProducto = idProducto.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaPrecio = precio.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaCantidad = cantidad.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaImporte = importe.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            //Crear varibale de objeto 
            List<DetalleVenta> objDVenta = new List<DetalleVenta>();

            //validacion 
            if (listaIdVenta.Count() == 0 | listaIdProducto.Count() == 0 | listaPrecio.Count() == 0 | listaCantidad.Count() == 0 | listaImporte.Count() == 0)
            {
                return View();
            }

		[HttpPost]
		public IActionResult CrearMultiples(List<DetalleVenta> detalleVentas)
		{
			// Logic . . .
			return View();
		}


		/// <summary>
		/// Método que se encarga de crear multiples detalles de venta. 
		/// A diferencia de <see cref="CrearMultiples(Lista{DetalleVenta})"/> 
		/// este método recibe una lista de <see cref="ProductosList"/> y 
		/// crea un detalle de venta por cada producto en la lista, sin 
		/// validar el modelo ni redireccionar a ninguna vista.
		/// </summary>
		/// <param name="productosList">Lista de productos con la cantidad a registrar</param></param>
		[HttpPost]
		public void CrearMultiples(List<ProductosList> productosList)
		{
			List<DetalleVenta> detalleVentas = new List<DetalleVenta>();
			Venta venta = _context.Ventas.OrderBy(v => v.Id).Last();

			foreach (var item in productosList)
			{
				var producto = (_context.Productos.Find(item.Id));
				detalleVentas.Add(new DetalleVenta
				{
					VentaId = venta.Id,
					ProductoId = producto.Id,
					PrecioUnidad = (Decimal)producto.Precio,
					Cantidad = item.Cantidad,
					Importe = (Decimal)producto.Precio * item.Cantidad
				});
			}

			_context.DetalleVentas.AddRange(detalleVentas);
			_context.SaveChanges();
		}

		[HttpGet]
		public IActionResult Editar(int id)
		{
			DetalleVenta estudiante = _context.DetalleVentas.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(DetalleVenta detalleVenta)
		{
			if (ModelState.IsValid)
			{
				_context.DetalleVentas.Update(detalleVenta);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", detalleVenta);
		}

        [HttpGet]
        public IActionResult EditarMultiple()
        {
            var DVentas = _context.DetalleVentas.ToList();
            return View(DVentas);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<DetalleVenta> detalleVentas)
        {
            if (ModelState.IsValid)
            {
                foreach (var detalleVenta in detalleVentas)
                {
                    _context.DetalleVentas.Update(detalleVenta);

                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalleVentas);
        }

        [HttpGet]
		public IActionResult Eliminar(int id)
		{
			DetalleVenta estudiante = _context.DetalleVentas.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(DetalleVenta detalleVenta)
		{
			_context.DetalleVentas.Remove(detalleVenta);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult EliminarMultiples()
        {
            IEnumerable<DetalleVenta> detalleVentas = _context.DetalleVentas.OrderByDescending(x => x.Id).Take(3);

            _context.DetalleVentas.RemoveRange(detalleVentas);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
