using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using proy_caguamanta.Data;
using proy_caguamanta.Models;

namespace proy_caguamanta.Controllers
{
    public class VentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        private static List<ProductosList> _productos;
        private static List<SelectListItem> options;
        private static List<Venta> listaVenta;

        private int cantidad;
        private int idEmpleado;
        private int idCliente;
        private double precio;
        private double total;
        private double cambio;

        public VentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo que se encarga de cargar la vista principal de la venta.
        /// </summary>
        /// <param name="pago">Cantidad de dinero que el cliente paga</param>
        /// <param name="idCliente">Id del cliente que realiza la compra, 1001 por defecto</param>
        /// <param name="idEmpleado">Id del empleado que realiza la venta, 2001 por defecto</param>
        public ActionResult Index(double pago, int idCliente = 1001, int idEmpleado = 2001)
        {
            CargarDatos(pago, idCliente, idEmpleado);
            ViewBag.IdVenta = _context.Ventas.OrderBy(v => v.Id).Last().Id + 1;
            ViewBag.IdCliente = this.idCliente;
            ViewBag.IdEmpleado = this.idEmpleado;
            return View();
        }

        public IActionResult Listar()
        {
            listaVenta = _context.Ventas.ToList();
            return View(listaVenta);
        }

        // sobrecaragr el metodo
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Venta venta)
        {
            //validar
            if (ModelState.IsValid)
            {
                // agregar, guardar y redireccionar
                venta.IdEmpleado = venta.IdEmpleado == 0 ? 1001 : 0;
                venta.IdCliente = venta.IdCliente == 0 ? 2001 : 0;
                _context.Ventas.Add(venta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Crear", venta);
            }
        }

        [HttpPost]
        public ActionResult AgregarProducto(int productoId, int cantidadProducto)
        {
            Producto producto = _context.Productos.Find(productoId);

            if (_productos == null)
            {
                _productos = new List<ProductosList>();
            }

            double subtotal = producto.Precio * cantidadProducto;
            ProductosList productoList = new ProductosList
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Cantidad = cantidadProducto,
                SubTotal = subtotal
            };

            _productos.Add(productoList);
            return RedirectToAction("Index");
        }

        public ActionResult LimpiarTabla()
        {
            _productos.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult FinalizarVenta()
        {
            DetalleVentaController _detalleVenta = new DetalleVentaController(_context);

            CalcularTotal();
            Venta venta = new Venta
            {
                FechaVenta = DateTime.Today,
                IdEmpleado = this.idEmpleado,
                IdCliente = this.idCliente,
                Importe = (decimal)total
            };

            Crear(venta);
            _detalleVenta.CrearMultiples(_productos);
            LimpiarTabla();
            return RedirectToAction("Index");
        }

        private void CargarDatos(double pago, int idCliente = 1, int idEmpleado = 1)
        {
            CargarProductos();
            CalcularTotal();
            CalcularCambio(pago);
            // Incrementar el 'Id' de la ultima venta para obtener el actual. No funciona con '++', se le tiene que agregar '+ 1'
            this.idEmpleado = idEmpleado;
            this.idCliente = idCliente;
        }

        private void CargarProductos()
        {
            options = _context.Productos.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).ToList();

            ViewBag.SelectListProductos = options;
            ViewBag.Productos = _productos;
        }

        private void CalcularTotal()
        {
            total = _productos != null ? _productos.Sum(p => p.SubTotal) : 0;
            ViewBag.Total = total;
        }

        private void CalcularCambio(double pago)
        {
            cambio = pago <= 0 ? 0 : pago - total;

            ViewBag.Pago = pago;
            ViewBag.Cambio = cambio >= 0 ? cambio : 0;
        }
    }
}
