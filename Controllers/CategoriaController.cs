using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class CategoriaController : Controller
    {
        //Crear variable 
        public readonly ApplicationDbContext _context;

        //Crear constructor
        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Metodos de accion
        public IActionResult Index()
        {
            List<Categoria> listaCategoria = _context.Categorias.ToList();
            return View(listaCategoria);
        }
        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Categoria categoria)
        {
            if (categoria.Id == 0 && categoria.Nombre != null && categoria.Descripcion != null)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", categoria);
            }

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Categoria categoria = _context.Categorias.Find(id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Editar(Categoria categoria)
        {
            if (categoria.Id != 0 && categoria.Nombre != null && categoria.Descripcion != null)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Editar", categoria);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Categoria estudiante = _context.Categorias.Find(id);
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Eliminar(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // metodos de multiples registros

        // metodod de sobre carga de MULTIPLE
        [HttpGet]
        public IActionResult CrearMultiple()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearMultiple(Categoria categoria)
        {
            // declarar las variables que utilizaremos 
            string Nombre = Request.Form["Nombre"];
            string Descripcion = Request.Form["Descripcion"];


            //generacion de las listas

            var listaNombre = Nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaDescripcion = Descripcion.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();


            // validacion
            if (listaNombre.Count == 0 | listaDescripcion.Count == 0)
            {
                // en caso de no cumplir con la validacion
                return View("CrearMultiple", categoria);
            }
            //creamos el objeto

            List<Categoria> objCategoria = new List<Categoria>();

            //bucle

            for (int i = 0; i <= 2; i++)
            {
                objCategoria.Add(new Categoria
                {
                    Nombre = listaNombre[i],
                    Descripcion = listaDescripcion[i]
                });

            }

            // agregar, guardar y redireccionar
            _context.AddRange(objCategoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // editar multiples
        [HttpGet]
        public IActionResult EditarMultiple()
        {
            // Retrieve the list of students to edit
            var categoria = _context.Categorias.ToList();
            return View(categoria);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<Categoria> categorias)
        {
            // Validar la entrada
            if (categorias == null || !categorias.Any())
            {
                //En caso de que no haya una entrada válida, regrese a la vista con una lista vacía
                return View(new List<Categoria>());
            }
            // Recorra la lista de estudiantes y actualice cada uno
            foreach (var categoria in categorias)
            {
                // Validar cada objeto de estudiante si es necesario
                if (categoria.Id != 0 && categoria.Nombre != null && categoria.Descripcion != null)
                {
                    //
                    _context.Entry(categoria).State = EntityState.Modified;
                }
            }

            // Guarda cambios en la base de datos
            _context.SaveChanges();

            // Redirecciona al index o vista principal
            return RedirectToAction("Index");
        }
    }
}
