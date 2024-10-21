using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class UsuarioController : Controller
    {
        //Crear variable
        public readonly ApplicationDbContext _context;

        //Crear constructor 
        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Crear un metodo de accion
        public IActionResult Index() {
            List<Usuario> listaUsusario = _context.Usuarios.ToList();
            return View(listaUsusario);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", usuario);
            }

        }

    }
}
