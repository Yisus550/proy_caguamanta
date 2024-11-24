using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class PuestoController : Controller
	{
		public readonly ApplicationDbContext _context;

		public PuestoController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<Puesto> listPuesto = _context.Puestos.ToList();
			return View(listPuesto);
		}
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Puesto puesto)
		{
			//validar
			if (puesto.Id == 0 && puesto.Nombre != null && puesto.Sueldo != null)
			{
				// agregar, guardar y redireccionar
				_context.Puestos.Add(puesto);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", puesto);
			}
		}
		[HttpGet]
		public IActionResult Editar(int id)
		{
			Puesto estudiante = _context.Puestos.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Puesto puesto)
		{
			if (puesto.Id != 0 && puesto.Nombre != null && puesto.Sueldo != null)
			{
				_context.Puestos.Update(puesto);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", puesto);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Puesto estudiante = _context.Puestos.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Puesto puesto)
		{
			_context.Puestos.Remove(puesto);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        // crear multiples registros
        [HttpGet]
        public IActionResult CrearMultiple()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearMultiple(Puesto puesto)
        {
            // declarar las variables que utilizaremos
            string Nombre = Request.Form["Nombre"];
            string Sueldo = Request.Form["Sueldo"];

            //generacion de las listas
            var listaNombre = Nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaSueldo = Sueldo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            // validacion
            if (listaNombre.Count == 0 | listaSueldo.Count == 0)
            {
                // en caso de no cumplir con la validacion
                return View("CrearMultiple", puesto);
            }
            //creamos el objeto

            List<Puesto> objPuesto = new List<Puesto>();

            //bucle

            for (int i = 0; i <= 4; i++)
            {
                objPuesto.Add(new Puesto
                {
                    Nombre = listaNombre[i],
                    Sueldo = Convert.ToDecimal(listaSueldo[i])
                });

            }

            // agregar, guardar y redireccionar
            _context.Puestos.AddRange(objPuesto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // editar multiples registros 
        [HttpGet]
        public IActionResult EditarMultiple()
        {
            // Recupera la lista de categorias para editar
            var puestos = _context.Puestos.ToList();
            return View(puestos);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<Puesto> puestos)
        {
            // Validar la entrada
            if (puestos == null || !puestos.Any())
            {
                //En caso de que no haya una entrada válida, regrese a la vista con una lista vacía
                return View(new List<Puesto>());
            }
            // Recorre la lista de categorias y actualiza cada uno
            foreach (var puesto in puestos)
            {
                // Validar cada objeto de estudiante si es necesario
                if (puesto.Id != 0 && puesto.Nombre != null && puesto.Sueldo != null)
                {
                    // Marca la entidad como modificada
                    _context.Entry(puesto).State = EntityState.Modified;
                }
            }

            // Guarda cambios en la base de datos
            _context.SaveChanges();

            // Redirecciona al index o vista principal
            return RedirectToAction("Index");
        }

        // eliminar multitples
        [HttpGet]
        public IActionResult EliminarMultiple(int id)
        {
            // genera una lista con los registros seleccionados con take de abajo hacia arriba
            IEnumerable<Puesto> puestos = _context.Puestos.OrderByDescending(e => e.Id).Take(3);

            // elimina, guarda y redirecciona
            _context.Puestos.RemoveRange(puestos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
