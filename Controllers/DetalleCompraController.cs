using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class DetalleCompraController : Controller
    {
        //Crear variable
        public readonly ApplicationDbContext _context;

        //Crear Constructor
        public DetalleCompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Metedo de accion 
        public IActionResult Index() 
        { 
            List<DetalleCompra> listaDetalleCompra = _context.DetalleCompras.ToList();
            return View(listaDetalleCompra);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(DetalleCompra detalleCompra)
        {
            if (detalleCompra.Id == 0 && detalleCompra.IdCompra != null && detalleCompra.IdProducto != null && detalleCompra.PrecioUnidad != null && detalleCompra.Cantidad != null && detalleCompra.Importe != null)
            {
                _context.DetalleCompras.Add(detalleCompra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", detalleCompra);
            }

        }
    }
}
