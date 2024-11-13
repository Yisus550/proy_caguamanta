using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Models;
using System.Diagnostics;

namespace proy_caguamanta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Login()
        {
            // TODO: Implementar la lógica de autenticación
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
