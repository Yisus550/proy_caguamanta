﻿using Microsoft.AspNetCore.Mvc;
using proy_caguamanta.Data;
using proy_caguamanta.Models;
using System.ComponentModel;

namespace proy_caguamanta.Controllers
{
    public class CompraController : Controller
    {
        //Crear variable 
        public readonly ApplicationDbContext _context;

        //Crear constructor
        public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Metodos de accion
        public IActionResult Index() 
        {
            List<Compra> listaCompra = _context.Compras.ToList();
            return View(listaCompra);
        }

        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Compras.Add(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", compra);
            }

        }
    }
}
