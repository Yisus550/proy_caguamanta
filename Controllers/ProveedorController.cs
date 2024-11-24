using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class ProveedorController : Controller
	{
		public readonly ApplicationDbContext _context;

		public ProveedorController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{ 
			List<Proveedor> listaProveedor = _context.Proveedores.ToList();
		return View(listaProveedor);
		}
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Proveedor proveedor)
		{
			//validar
			if (proveedor.Id == 0 && proveedor.Nombre != null && proveedor.Apellido != null && proveedor.Telefono != null && proveedor.Correo != null && proveedor.Empresa != null)
			{
				// agregar, guardar y redireccionar
				_context.Proveedores.Add(proveedor);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", proveedor);
			}
		}

		[HttpGet]
		public IActionResult Editar(int id)
		{
			Proveedor estudiante = _context.Proveedores.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Proveedor proveedor)
		{
			if (proveedor.Id != 0 && proveedor.Nombre != null && proveedor.Apellido != null && proveedor.Telefono != null && proveedor.Correo != null && proveedor.Empresa != null)
			{
				_context.Proveedores.Update(proveedor);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", proveedor);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Proveedor estudiante = _context.Proveedores.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Proveedor proveedor)
		{
			_context.Proveedores.Remove(proveedor);
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
        public IActionResult CrearMultiple(Proveedor proveedor)
        {
            // declarar las variables que utilizaremos
            string Nombre = Request.Form["Nombre"];
            string Apellido = Request.Form["Apellido"];
            string Telefono = Request.Form["Telefono"];
            string Correo = Request.Form["Correo"];
            string Empresa = Request.Form["Empresa"];

            //generacion de las listas
            var listaNombre = Nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaApellido = Apellido.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaTelefono = Telefono.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaCorreo = Correo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaEmpresa = Empresa.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            // validacion
            if (listaNombre.Count == 0 | listaApellido.Count == 0 | listaTelefono.Count == 0 | listaCorreo.Count == 0 | listaEmpresa.Count == 0)
            {
                // en caso de no cumplir con la validacion
                return View("CrearMultiple", proveedor);
            }
            //creamos el objeto

            List<Proveedor> objproveedor = new List<Proveedor>();

            //bucle

            for (int i = 0; i <= 4; i++)
            {
                objproveedor.Add(new Proveedor
                {
                    Nombre = listaNombre[i],
                    Apellido = listaApellido[i],
                    Telefono = listaTelefono[i],
                    Correo = listaCorreo[i],
                    Empresa = listaEmpresa[i],
                });

            }

            // agregar, guardar y redireccionar
            _context.Proveedores.AddRange(objproveedor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // editar multiples registros 
        [HttpGet]
        public IActionResult EditarMultiple()
        {
            // Recupera la lista de categorias para editar
            var proveedores = _context.Proveedores.ToList();
            return View(proveedores);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<Proveedor> proveedores)
        {
            // Validar la entrada
            if (proveedores == null || !proveedores.Any())
            {
                //En caso de que no haya una entrada válida, regrese a la vista con una lista vacía
                return View(new List<Proveedor>());
            }
            // Recorre la lista de categorias y actualiza cada uno
            foreach (var proveedor in proveedores)
            {
                // Validar cada objeto de estudiante si es necesario
                if (proveedor.Id != 0 && proveedor.Nombre != null && proveedor.Apellido != null && proveedor.Telefono != null && proveedor.Correo != null && proveedor.Empresa != null)
                {
                    // Marca la entidad como modificada
                    _context.Entry(proveedor).State = EntityState.Modified;
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
            IEnumerable<Proveedor> proveedores = _context.Proveedores.OrderByDescending(e => e.Id).Take(3);

            // elimina, guarda y redirecciona
            _context.Proveedores.RemoveRange(proveedores);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
