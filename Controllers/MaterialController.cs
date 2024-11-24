using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class MaterialController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void Cargar()
        {
			ViewBag.CategoriaID = SelectListCategorias();
			ViewBag.ProveedorID = SelectListProveedores();
		}
        public IActionResult Index()
        {
            List<Material> listMaterial = _context.Materiales.ToList();
            return View(listMaterial);
        }
        // sobrecaragr el metodo
        [HttpGet]
        public IActionResult Crear()
        {
            Cargar();

			return View();
        }
        [HttpPost]
        public IActionResult Crear(Material material)
        {
            //validar
            if (material.Id == 0 || material.Id == null && material.Nombre != null && material.ProveedorId != null && material.Cantidad != null && material.Costo != null && material.CategoriaId != null)
            {
                // agregar, guardar y redireccionar
                _context.Materiales.Add(material);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
				Cargar();
				return View("Crear", material);
            }
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
			Cargar();
			Material estudiante = _context.Materiales.Find(id);
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(Material material)
        {
            if (material.Id != 0 && material.Nombre != null && material.ProveedorId != null && material.Cantidad != null && material.Costo != null && material.CategoriaId != null)
            {
                _context.Materiales.Update(material);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
			Cargar();
			return View("Editar", material);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Material estudiante = _context.Materiales.Find(id);
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Eliminar(Material material)
        {
            _context.Materiales.Remove(material);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // crear multiples registros
        [HttpGet]
        public IActionResult CrearMultiple()
        {
			Cargar();
			return View();
        }
        [HttpPost]
        public IActionResult CrearMultiple(Material material)
        {
            // declarar las variables que utilizaremos
            string Nombre = Request.Form["Nombre"];
            string Costo = Request.Form["Costo"];
            string ProveedorId = Request.Form["ProveedorId"];
            string CategoriaId = Request.Form["CategoriaId"];


            //generacion de las listas
            var listaNombre = Nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaCosto = Costo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaProveedorId = ProveedorId.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaCategoriaId = CategoriaId.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            // validacion
            if (listaNombre.Count == 0 | listaCosto.Count == 0 | listaProveedorId.Count == 0 | listaCategoriaId.Count == 0)
            {
				Cargar();
				// en caso de no cumplir con la validacion
				return View("CrearMultiple", material);
            }
            //creamos el objeto

            List<Material> objMaterial = new List<Material>();

            //bucle

            for (int i = 0; i <= 4; i++)
            {
                objMaterial.Add(new Material
                {
                    Nombre = listaNombre[i],
                    Costo = Convert.ToDecimal(listaCosto[i]),
                    ProveedorId = Convert.ToInt16(listaProveedorId[i]),
                    CategoriaId = Convert.ToInt16(listaCategoriaId[i])
                });

            }

            // agregar, guardar y redireccionar
            _context.Materiales.AddRange(objMaterial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // editar multiples registros 
        [HttpGet]
        public IActionResult EditarMultiple()
        {
			Cargar();
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
				Cargar();
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

		private List<SelectListItem> SelectListCategorias()
		{
			return _context.Categorias.Select(d => new SelectListItem
			{
				Text = d.Nombre,
				Value = d.Id.ToString()
			}).ToList();
		}
		private List<SelectListItem> SelectListProveedores()
		{
			return _context.Proveedores.Select(d => new SelectListItem
			{
				Text = d.Nombre,
				Value = d.Id.ToString()
			}).ToList();
		}
	}
}
