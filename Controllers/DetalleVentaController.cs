﻿using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class DetalleVentaController : Controller
    {
        //Crear variable
        public readonly ApplicationDbContext _context;

        //Crear constructor
        public DetalleVentaController(ApplicationDbContext context)
        {
            _context = context; 
        }

        //Metodos de accion
        public IActionResult Index() 
        {
            List<DetalleVenta> listaDetalleVenta = _context.DetalleVentas.ToList();
            return View(listaDetalleVenta);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(DetalleVenta detalleVenta)
        {
            if (ModelState.IsValid)
            {
                _context.DetalleVentas.Add(detalleVenta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", detalleVenta);
            }

        }

    }
}
