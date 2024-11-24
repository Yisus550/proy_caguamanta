using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
	public class ClienteController : Controller
	{
		//Crear variable
		public readonly ApplicationDbContext _context;

		//Crear constructor
		public ClienteController(ApplicationDbContext context)
		{
			_context = context;
		}

		//Metodos de Accion
		public IActionResult Index()
		{
			List<Cliente> listaCliente = _context.Clientes.ToList();
			return View(listaCliente);
		}

		[HttpGet]
		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Crear(Cliente cliente)
		{
			if (cliente.Id == null || cliente.Id == 0 && cliente.Nombre != null && cliente.Telefono != null)
			{
				_context.Clientes.Add(cliente);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", cliente);
			}

		}

        [HttpGet]
		public IActionResult Editar(int id)
		{
			Cliente cliente = _context.Clientes.Find(id);
			return View(cliente);
		}

		[HttpPost]
		public IActionResult Editar(Cliente cliente)
		{
			if (cliente.Id != 0 && cliente.Nombre != null && cliente.Telefono != null)
			{
				_context.Clientes.Update(cliente);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", cliente);
		}
        [HttpGet]
		public IActionResult Eliminar(int id)
		{
			Cliente cliente = _context.Clientes.Find(id);
			return View(cliente);
		}

		[HttpPost]
		public IActionResult Eliminar(Cliente cliente)
		{
			_context.Clientes.Remove(cliente);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        // crear multiples registros
        [HttpGet]
        public IActionResult CrearMulti()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearMulti(Cliente cliente)
        {
            // declarar las variables que utilizaremos
            string Nombre = Request.Form["Nombre"];
            string Telefono = Request.Form["Telefono"];

            //generacion de las listas
            var listaNombre = Nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaTelefono = Telefono.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            // validacion
            if (listaNombre.Count == 0 | listaTelefono.Count == 0)
            {
                // en caso de no cumplir con la validacion
                return View("CrearMultiple", cliente);
            }
            //creamos el objeto

            List<Cliente> objCliente = new List<Cliente>();

            //bucle

            for (int i = 0; i <= 4; i++)
            {
                objCliente.Add(new Cliente
                {
                    Nombre = listaNombre[i],
                    Telefono = listaTelefono[i]
                });

            }

            // agregar, guardar y redireccionar
            _context.Clientes.AddRange(objCliente);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // editar multiples registros 
        [HttpGet]
        public IActionResult EditarMultiple()
        {
            // Recupera la lista de categorias para editar
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<Cliente> clientes)
        {
            // Validar la entrada
            if (clientes == null || !clientes.Any())
            {
                //En caso de que no haya una entrada válida, regrese a la vista con una lista vacía
                return View(new List<Cliente>());
            }
            // Recorre la lista de categorias y actualiza cada uno
            foreach (var cliente in clientes)
            {
                // Validar cada objeto de estudiante si es necesario
                if (cliente.Id != 0 && cliente.Nombre != null && cliente.Telefono != null)
                {
                    // Marca la entidad como modificada
                    _context.Entry(cliente).State = EntityState.Modified;
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
            IEnumerable<Cliente> clientes = _context.Clientes.OrderByDescending(e => e.Id).Take(3);

            // elimina, guarda y redirecciona
            _context.Clientes.RemoveRange(clientes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
