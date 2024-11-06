﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
            ViewBag.Categoria = GetPuestosSelectList();
            return View();
		}
		[HttpPost]
		public IActionResult Crear(Material material)
		{
			//validar
			if (material.IdMaterial == 0 && material.Nombre != null && material.Proveedor != null && material.Cantidad != null && material.Costo != null && material.IdCategoria != null)
			{
				// agregar, guardar y redireccionar
				_context.Materiales.Add(material);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return View("Crear", material);
			}
		}
        // metodo para mandar los puestos 
        private List<SelectListItem> GetPuestosSelectList()
        {
            return _context.Categorias.Select(d => new SelectListItem
            {
                Text = d.Nombre,
                Value = d.Id.ToString(),
                Selected = false
            }).ToList();
        }
    }
}
