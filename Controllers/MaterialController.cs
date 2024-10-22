using Microsoft.AspNetCore.Mvc;
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

		public IActionResult Index()
		{
			List<Material> listMaterial = _context.Materiales.ToList();
			return View(listMaterial);
		}
	}
}
