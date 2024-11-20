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
			if (cliente.Id == 0 && cliente.Nombre != null && cliente.Telefono != null)
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

	}
}
