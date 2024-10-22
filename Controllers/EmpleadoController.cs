using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class EmpleadoController : Controller
    {
        //Crear variable
        public readonly ApplicationDbContext _context;

        //Crear constructor 
        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Crear un metodo de accion
        public IActionResult Index() {
            List<Empleado> listaUsusario = _context.Empleados.ToList();
            return View(listaUsusario);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", empleado);
            }

        }

    }
}
