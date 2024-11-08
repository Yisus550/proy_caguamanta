using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Data;
using proy_caguamanta.Models;
using System.Diagnostics;

namespace proy_caguamanta.Controllers
{
	public class HomeController : Controller
	{
		public readonly ApplicationDbContext _context;

		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(Login login)
		{
			Empleado empleado_encontrado = await _context.Empleados
										   .Where(e => e.Correo == login.Correo &&
													   e.Contrasena == login.Contrasena
										   ).FirstOrDefaultAsync();
			if (empleado_encontrado == null)
			{
				return View();

			}
			else
			{
				return RedirectToAction("Index", "Venta");
			}


		}


		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(Empleado empleado)
		{
			//Empleado empleado_encontrado = await context.Empleados.Where(e => e.Contrasena == empleado.Contrasena)
			return RedirectToAction("Index", "Venta");
		}

		public IActionResult Registros()
		{
			return View();
		}

		public IActionResult Categoria()
		{
			return RedirectToAction("Index", "Categoria");
		}

		public IActionResult Cliente()
		{
			return RedirectToAction("Index", "Cliente");
		}

		public IActionResult Compra()
		{
			return RedirectToAction("Index", "Compra");
		}

		public IActionResult DetalleCompra()
		{
			return RedirectToAction("Index", "DetalleCompra");
		}

		public IActionResult DetalleVenta()
		{
			return RedirectToAction("Index", "DetalleVenta");
		}

		public IActionResult Empleado()
		{
			return RedirectToAction("Index", "Empleado");
		}

		public IActionResult Material()
		{
			return RedirectToAction("Index", "Material");
		}

		public IActionResult Producto()
		{
			return RedirectToAction("Index", "Producto");
		}

		public IActionResult Proveedor()
		{
			return RedirectToAction("Index", "Proveedor");
		}

		public IActionResult Puesto()
		{
			return RedirectToAction("Index", "Puesto");
		}

		public IActionResult Venta()
		{
			return RedirectToAction("Index", "Venta");
		}
	}
}
