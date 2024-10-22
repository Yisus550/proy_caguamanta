using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class ProductoController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Producto> listaProducto = _context.Productos.ToList();
            return View(listaProducto);
        }
    }
}
