using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;
using System.ComponentModel;

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
            if (ModelState.IsValid)
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

        [HttpGet]
        public IActionResult CrearMulti()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CrearMulti(DetalleCompra detalleCompra)
        {
            //Creamos las varibales 
            string idCompra = Request.Form["IdCompra"];
            string idProducto = Request.Form["IdProducto"];
            string precio = Request.Form["PrecioUnidad"];
            string cantidad = Request.Form["Cantidad"];
            string importe = Request.Form["Importe"];

            //Creamos lista de los elementos de la variable 
            var listaIdCompra = idCompra.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaIdProducto = idProducto.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaPrecio = precio.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaCantidad = cantidad.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaImporte = importe.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            //Crear varibale de objeto 
            List<DetalleCompra> objDCompra = new List<DetalleCompra>();

            //validacion 
            if (listaIdCompra.Count() == 0 | listaIdProducto.Count() == 0 | listaPrecio.Count() == 0 | listaCantidad.Count() == 0 | listaImporte.Count() == 0)
            {
                return View();
            }

            //crear bucle
            for (int i = 0; i <= 2; i++)
            {
                objDCompra.Add(new DetalleCompra
                {
                    IdCompra = Convert.ToInt32(listaIdCompra[i]),
                    IdProducto = Convert.ToInt32(listaIdProducto[i]),
                    PrecioUnidad = Convert.ToDecimal(listaPrecio[i]),
                    Cantidad = Convert.ToInt32(listaCantidad[i]),
                    Importe = Convert.ToInt32(listaImporte[i])
                });
            }

            _context.AddRange(objDCompra);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
		public IActionResult Editar(int id)
		{
			DetalleCompra estudiante = _context.DetalleCompras.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(DetalleCompra detalleCompra)
		{
			if (ModelState.IsValid)
			{
				_context.DetalleCompras.Update(detalleCompra);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", detalleCompra);
		}

        [HttpGet]
        public IActionResult EditarMultiple()
        {
            var Dcompra = _context.DetalleCompras.ToList();
            return View(Dcompra);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<DetalleCompra> detalleCompras)
        {
            if (ModelState.IsValid)
            {
                foreach (var detalleCompra in detalleCompras)
                {
                    _context.DetalleCompras.Update(detalleCompra);

                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalleCompras);
        }

        [HttpGet]
		public IActionResult Eliminar(int id)
		{
			DetalleCompra estudiante = _context.DetalleCompras.Find(id);
			return View(estudiante);
		}
      
        [HttpPost]
		public IActionResult Eliminar(DetalleCompra detalleCompra)
		{
			_context.DetalleCompras.Remove(detalleCompra);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult EliminarMultiples()
        {
            IEnumerable<DetalleCompra> detalleCompras = _context.DetalleCompras.OrderByDescending(x => x.Id).Take(3);

            _context.DetalleCompras.RemoveRange(detalleCompras);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
