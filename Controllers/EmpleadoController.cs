﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class EmpleadoController : Controller
    {
        /// metodo de listado de puestos
        private List<SelectListItem> GetPuestosSelectList()
        {
            return _context.Puestos.Select(d => new SelectListItem
            {
                Text = d.Nombre,
                Value = d.Id.ToString()
            }).ToList();
        }

        //Crear variable
        public readonly ApplicationDbContext _context;

        //Crear constructor 
        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Crear un metodo de accion
        public IActionResult Index() {
            List<Empleado> listaUsusario = _context.Empleados.ToList();
            return View(listaUsusario);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Puesto = GetPuestosSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            if (empleado.Id == 0 && empleado.Nombre != null && empleado.Apellido != null && empleado.Correo != null && empleado.Contrasena != null && empleado.Telefono != null && empleado.Direccion != null && empleado.Estado != null && empleado.PuestoId != 0)
            {
                _context.Empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Puesto = GetPuestosSelectList();
                return View("Crear", empleado);
            }

        }
		[HttpGet]
		public IActionResult Editar(int id)
		{

			Empleado estudiante = _context.Empleados.Find(id);
            ViewBag.Puesto = GetPuestosSelectList();
            return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Empleado empleado)
		{
			if (empleado.Id != 0 && empleado.Nombre != null && empleado.Apellido != null && empleado.Correo != null && empleado.Contrasena != null && empleado.Telefono != null && empleado.Direccion != null && empleado.Estado != null && empleado.PuestoId != 0)
			{
				_context.Empleados.Update(empleado);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
            ViewBag.Puesto = GetPuestosSelectList();
            return View("Editar", empleado);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Empleado estudiante = _context.Empleados.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Empleado empleado)
		{
			_context.Empleados.Remove(empleado);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
