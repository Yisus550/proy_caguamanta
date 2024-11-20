using Microsoft.AspNetCore.Mvc;
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
			if (cliente.Id == null && cliente.Nombre != null && cliente.Telefono != null)
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
        public IActionResult CrearMulti()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CrearMulti(Cliente cliente)
        {
            //Creamos las varibales 
            string nombre = Request.Form["Nombre"];
            string telefono = Request.Form["Telefono"];

            //Creamos lista de los elementos de la variable 
            var listaNombre = nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaTelefono = telefono.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            //Crear varibale de objeto 
            List<Cliente> objClientes = new List<Cliente>();

            //validacion 
            if (listaNombre.Count() == 0 | listaTelefono.Count() == 0)
            {
                return View();
            }

            //crear bucle
            for (int i = 0; i <= 2; i++)
            {
                objClientes.Add(new Cliente
                {
                    Nombre = listaNombre[i],
                    Telefono = listaTelefono[i]
                });
            }

            _context.AddRange(objClientes);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
			if (cliente != null && cliente.Nombre != null && cliente.Telefono != null)
			{
				_context.Clientes.Update(cliente);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", cliente);
		}

        [HttpGet]
        public IActionResult EditarMultiple()
        {
            var clinete = _context.Clientes.ToList();
            return View(clinete);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<Cliente> clientes)
        {
            if (ModelState.IsValid)
            {
                foreach (var cliente in clientes)
                {
					_context.Clientes.Update(cliente);
                    
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
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

        [HttpGet]
        public IActionResult EliminarMultiples()
        {
            IEnumerable<Cliente> clientes = _context.Clientes.OrderByDescending(x => x.Id).Take(3);

            _context.Clientes.RemoveRange(clientes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
