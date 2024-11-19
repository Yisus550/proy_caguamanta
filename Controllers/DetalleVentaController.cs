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

		public IActionResult CrearMultiples(List<ProductosList> productosList)
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
			return RedirectToAction("Index");
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

	}
}
