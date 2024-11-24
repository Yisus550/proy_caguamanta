using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        private void Cargar()
        {
            ViewBag.Puesto = GetPuestosSelectList();
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
            Cargar();
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
                Cargar();
                return View("Crear", empleado);
            }

        }
		[HttpGet]
		public IActionResult Editar(int id)
		{

			Empleado estudiante = _context.Empleados.Find(id);
            Cargar();
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
            Cargar();
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
        // crear multiples registros
        [HttpGet]
        public IActionResult CrearMultiple()
        {
            Cargar();
            return View();
        }
        [HttpPost]
        public IActionResult CrearMultiple(Empleado empleado)
        {
            // declarar las variables que utilizaremos
            string Nombre = Request.Form["Nombre"];
            string Apellido = Request.Form["Apellido"];
            string Correo = Request.Form["Correo"];
            string Contrasena = Request.Form["Contrasena"];
            string Telefono = Request.Form["Telefono"];
            string Direccion = Request.Form["Direccion"];
            string PuestoId = Request.Form["PuestoId"];
            string Estado = Request.Form["Estado"];

            //generacion de las listas
            var listaNombre = Nombre.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaApellido = Apellido.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaCorreo = Correo.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaContrasena = Contrasena.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaTelefono = Telefono.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaDireccion = Direccion.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaPuestoId = PuestoId.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            var listaEstado = Estado.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            // validacion
            if (listaNombre.Count == 0 | listaApellido.Count == 0 | listaCorreo.Count == 0 | listaContrasena.Count == 0 | listaTelefono.Count == 0 | listaDireccion.Count == 0 | listaPuestoId.Count == 0 | listaEstado.Count == 0)
            {
                // en caso de no cumplir con la validacion
                Cargar();
                return View("CrearMultiple", empleado);
            }
            //creamos el objeto

            List<Empleado> objEmpleado = new List<Empleado>();

            //bucle

            for (int i = 0; i <= 4; i++)
            {
                objEmpleado.Add(new Empleado
                {
                    Nombre = listaNombre[i],
                    Apellido = listaApellido[i],
                    Correo = listaCorreo[i],
                    Contrasena = listaContrasena[i],
                    Telefono = listaTelefono[i],
                    Direccion = listaDireccion[i],
                    PuestoId = Convert.ToInt16(listaPuestoId[i]),
                    Estado = listaEstado[i]
                });

            }

            // agregar, guardar y redireccionar
            _context.Empleados.AddRange(objEmpleado);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // editar multiples registros 
        [HttpGet]
        public IActionResult EditarMultiple()
        {
            // Recupera la lista de categorias para editar
            var empleado = _context.Empleados.ToList();
            Cargar();
            return View(empleado);
        }

        [HttpPost]
        public IActionResult EditarMultiple(List<Empleado> empleados)
        {
            // Validar la entrada
            if (empleados == null || !empleados.Any())
            {
                //En caso de que no haya una entrada válida, regrese a la vista con una lista vacía
                Cargar();
                return View(new List<Empleado>());
            }
            // Recorre la lista de categorias y actualiza cada uno
            foreach (var empleado in empleados)
            {
                // Validar cada objeto de estudiante si es necesario
                if (empleado.Id != 0 && empleado.Nombre != null && empleado.Apellido != null && empleado.Correo != null && empleado.Contrasena != null && empleado.Telefono != null && empleado.Direccion != null && empleado.Estado != null && empleado.PuestoId != 0)
                {
                    // Marca la entidad como modificada
                    _context.Entry(empleado).State = EntityState.Modified;
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
            IEnumerable<Categoria> categorias = _context.Categorias.OrderByDescending(e => e.Id).Take(3);

            // elimina, guarda y redirecciona
            _context.Categorias.RemoveRange(categorias);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
