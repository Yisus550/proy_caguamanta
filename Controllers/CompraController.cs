using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;
using System.ComponentModel;

namespace proy_caguamanta.Controllers
{
    public class CompraController : Controller
    {
        //Crear variable 
        public readonly ApplicationDbContext _context;

		private static List<MaterialesList> _Material;
		private static List<SelectListItem> options;
		private static List<SelectListItem> EmpleadoC;
		private static List<SelectListItem> ProveedorC; 
		private static List<Compra> ListaCompra;

		private static int cantidad;
		private static int idEmpleadoRecover;
		private static int idProveedorRecover;
		private static double precio;
		private static double total;

		//Crear constructor
		public CompraController(ApplicationDbContext context)
        {
            _context = context;
        }

		public ActionResult LimpiarTabla()
		{
			_Material.Clear();
			return RedirectToAction("Index");
		}

		private void CargarMaterial()
		{
			options = _context.Materiales.Select(p => new SelectListItem
			{
				Text = p.Nombre,
				Value = p.Id.ToString()
			}).ToList();

			ViewBag.SelectListMateriales = options;
			ViewBag.Material = _Material;
		}
		private void CargarEmpleado()
		{
			EmpleadoC = _context.Empleados.Select(e => new SelectListItem
			{
            Text= e.Nombre,
			Value= e.Id.ToString()
			}).ToList();

			ViewBag.SelectEmpleado = EmpleadoC;
		}
		private void CargarProveedor()
		{
			ProveedorC = _context.Proveedores.Select(e => new SelectListItem
			{
				Text = e.Nombre,
				Value = e.Id.ToString()
			}).ToList();

			ViewBag.SelectProveedor = ProveedorC;
		}

		private void CargarDatos(double pago, int idProveedor, int idEmpleado)
		{
			CargarMaterial();
			CargarProveedor();
			CargarEmpleado();
			CalcularTotal();
			idEmpleadoRecover = idEmpleado;
			idProveedorRecover = idProveedor;
		}
		private void CalcularTotal()
		{
			total = (double)(_Material != null ? _Material.Sum(p => p.SubTotal) : 0);
			ViewBag.Total = total; 
		}

		//Metodos de accion
		public IActionResult Index(double pago = 0, int idProveedor = 1, int idEmpleado = 1) 
        {
			CargarDatos(pago, idProveedor, idEmpleado);
			if (_context.Compras.Count() == 0)
			{
				ViewBag.IdCompra = 1;
			}
			else
			{
				ViewBag.IdCompra = _context.Compras.OrderBy(v => v.Id).Last().Id + 1;// toma el valor de la ultima venta y le suma 1 
			}

			ViewBag.IdEmpleado = idEmpleadoRecover;
			ViewBag.IdProveedor = idProveedorRecover;
			return View();
		}

		public IActionResult Listar()
		{
			ListaCompra = _context.Compras.ToList();
			return View(ListaCompra);
		}	
		// metodo de finalizar compra
		public void CrearAlFinalizar(Compra compra)
		{
			compra.EmpleadoId = idEmpleadoRecover;
			compra.ProveedorId = idProveedorRecover;
			_context.Compras.Add(compra);
			_context.SaveChanges();
		}

		[HttpPost]
		public ActionResult AgregarMaterial(int MaterialId, int CantidadMaterial)
		{
			Material material = _context.Materiales.Find(MaterialId);

			if (_Material == null)
				_Material = new List<MaterialesList>();

			MaterialesList materialList = new MaterialesList
			{
				Id = material.Id,
				Nombre = material.Nombre,
				Precio = material.Costo,
				Cantidad = CantidadMaterial,
				SubTotal = material.Costo * CantidadMaterial
			};

			_Material.Add(materialList);
			return RedirectToAction("Index");
		}

		public ActionResult FinalizarCompra(int idEmpleado, int idProveedor)
		{
			DetalleCompraController _detalleCompra = new DetalleCompraController(_context);

			CalcularTotal();

			Compra compra = new Compra
			{
				FechaCompra = DateOnly.FromDateTime(DateTime.Today),
				EmpleadoId = idEmpleado,
				ProveedorId = idProveedor,
				Importe = total
			};
			

			CrearAlFinalizar(compra);
			_detalleCompra.CrearMultiples(_Material);
			_Material.Clear();
			return RedirectToAction("Index");
		}

		[HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Compra compra)
        {
            if (compra.Id == 0 && compra.EmpleadoId != 0 && compra.FechaCompra != null && compra.ProveedorId != 0 && compra.Importe != 0)
            {
				compra.EmpleadoId = idEmpleadoRecover;
				compra.ProveedorId = idProveedorRecover;
                _context.Compras.Add(compra);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", compra);
            }

        }

	

		[HttpGet]
		public IActionResult Editar(int id)
		{
			Compra estudiante = _context.Compras.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Editar(Compra compra)
		{
			if (compra.Id != 0 && compra.EmpleadoId != 0 && compra.FechaCompra != null && compra.ProveedorId != 0 && compra.Importe != 0)
			{
				_context.Compras.Update(compra);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Editar", compra);
		}

		[HttpGet]
		public IActionResult Eliminar(int id)
		{
			Compra estudiante = _context.Compras.Find(id);
			return View(estudiante);
		}

		[HttpPost]
		public IActionResult Eliminar(Compra compra)
		{
			_context.Compras.Remove(compra);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}
