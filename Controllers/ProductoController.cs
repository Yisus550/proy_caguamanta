using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class ProductoController : Controller
    {
        public readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

		/// metodo de listado de Categorias
		private List<SelectListItem> SelectListCategorias()
		{
			return _context.Categorias.Select(d => new SelectListItem
			{
				Text = d.Nombre,
				Value = d.Id.ToString()
			}).ToList();
		}
        private void Cargar()
        {
            ViewBag.Categoria = SelectListCategorias();

		}
        public IActionResult Index()
        {
			List<Producto> listaProducto = _context.Productos.ToList();
            return View(listaProducto);
        }
		// sobrecaragr el metodo
		[HttpGet]
		public IActionResult Crear()
		{
			Cargar();
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Producto producto)
		{
			//validar
			if (producto.Id == 0 && producto.Nombre != null && producto.Descripcion != null && producto.Precio != null && producto.Cantidad != null && producto.CategoriaId != null)
			{
				// agregar, guardar y redireccionar
				_context.Productos.Add(producto);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				Cargar();
				return View("Crear", producto);
			}

		}
        [HttpGet]
        public IActionResult CrearMulti()
        {
			Cargar();
			return View();
        }

        [HttpPost]
        public IActionResult CrearMulti(Producto producto)
        {
            //Creamos las varibales 
            string nombre = Request.Form["Nombre"];
            string descripcion = Request.Form["Descripcion"];
            string precio = Request.Form["Precio"];
            string cantidad = Request.Form["Cantidad"];

            //Creamos lista de los elementos de la variable 
            var listaNombre = nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaDescripcion = descripcion.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaPrecio = precio.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var listaCantidad = cantidad.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            //Crear varibale de objeto 
            List<Producto> objProducto = new List<Producto>();

            //validacion 
            if (listaNombre.Count() == 0 | listaDescripcion.Count() == 0 | listaPrecio.Count() == 0 | listaCantidad.Count() == 0)
            {
				Cargar();
				return View();
            }

            //crear bucle
            for (int i = 0; i <= 2; i++)
            {
                objProducto.Add(new Producto
                {
                    Nombre = listaNombre[i],
                    Descripcion = listaDescripcion[i],
                    Precio = Convert.ToDouble(listaPrecio[i]),
                    Cantidad = Convert.ToInt32(listaCantidad[i])
                });
            }

            _context.AddRange(objProducto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
		public IActionResult Editar(int id)
		{
			Cargar();
			Producto estudiante = _context.Productos.Find(id);
			return View(estudiante);
		}


		[HttpPost]
		public IActionResult Editar(Producto producto)
		{
			if (producto.Id != 0 && producto.Nombre != null && producto.Descripcion != null && producto.Precio != null && producto.Cantidad != null && producto.CategoriaId != null)
			{
				_context.Productos.Update(producto);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			Cargar();
			return View("Editar", producto);
		}

        // editar multiples registros 
        [HttpGet]
        public IActionResult EditarMultiple()
        {
			Cargar();
			// Recupera la lista de categorias para editar
			var proveedores = _context.Proveedores.ToList();
            return View(proveedores);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<Producto> productos)
        {
            // Validar la entrada
            if (productos == null || !productos.Any())
            {
				Cargar();
				//En caso de que no haya una entrada válida, regrese a la vista con una lista vacía
				return View(new List<Proveedor>());
            }
            // Recorre la lista de categorias y actualiza cada uno
            foreach (var producto in productos)
            {
                // Validar cada objeto de estudiante si es necesario
                if (producto.Id != 0 || producto.Id != null && producto.Nombre != null && producto.Descripcion != null && producto.Precio != null && producto.Cantidad != null && producto.CategoriaId != null)
                {
                    // Marca la entidad como modificada
                    _context.Entry(producto).State = EntityState.Modified;
                }
            }

            // Guarda cambios en la base de datos
            _context.SaveChanges();

            // Redirecciona al index o vista principal
            return RedirectToAction("Index");
        }


        [HttpGet]
		public IActionResult Eliminar(int id)
		{
			Producto producto = _context.Productos.Find(id);
			return View(producto);
		}

		[HttpPost]
		public IActionResult Eliminar(Producto producto)
		{
			_context.Productos.Remove(producto);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

        [HttpGet]
        public IActionResult EliminarMultiples()
        {
            IEnumerable<Producto> productos = _context.Productos.OrderByDescending(x => x.Id).Take(3);

            _context.Productos.RemoveRange(productos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
