using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;
using System.ComponentModel;

namespace proy_caguamanta.Controllers
{
    public class CompraController : Controller
    {
        //Crear variable 
        public readonly ApplicationDbContext _context;

        //Crear constructor
        public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Metodos de accion
        public IActionResult Index()
        {
            List<Compra> listaCompra = _context.Compras.ToList();
            return View(listaCompra);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Empleado = GetEmpleadoSelectList();
            ViewBag.Proveedor = GetPrveedorSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Compra compra)
        {
            if (compra.Id == 0 && compra.IdEmpleado != 0 && compra.FechaCompra != null && compra.IdProveedor != 0 && compra.Importe != 0)
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", compra);
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
        // metodo para mandar los proveedor 
        private List<SelectListItem> GetPrveedorSelectList()
        {
            return _context.Proveedores.Select(d => new SelectListItem
            {
                Text = d.Nombre, // valor mostrado
                Value = d.Id.ToString(), // valor tomado
                Selected = false
            }).ToList();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Compra compra = _context.Compras.Find(id);
            return View(compra);
        }

        [HttpPost]
        public IActionResult Editar(Compra compra)
        {
            if (compra.Id != 0 && compra.IdEmpleado != null && compra.FechaCompra != null && compra.IdProveedor != null && compra.Importe != null)
            {
                _context.Compras.Update(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Editar", compra);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Compra compra = _context.Compras.Find(id);
            return View(compra);
        }

        [HttpPost]
        public IActionResult Eliminar(Compra compra)
        {
            _context.Compras.Remove(compra);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
