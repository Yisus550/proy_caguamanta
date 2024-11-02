using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proy_caguamanta.Models
{
	public class Producto
	{
		[Key]
		[Required(ErrorMessage = "Este campo es requerido.")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(30, ErrorMessage = "La cadena de texto no puede sobrepasar los 30 caracteres")]
		[Display(Name = "Nombre del producto")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(80, ErrorMessage = "La cadena de texto no puede sobrepasar los 80 caracteres")]
		[Display(Name = "Descripción del producto")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
		[Display(Name = "Precio del producto")]
		public double Precio { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
		[Display(Name = "Cantidad del producto")]
		public int Cantidad { get; set; }

		// llave foranea 
		[ForeignKey("Categoria")]
		public int IdCategoria { get; set; }
		// navegacion
		public Categoria Categoria { get; set; }

		// relacion de 1:N
		public List<DetalleVenta> DetalleVentas { get; set; }
		
	}
}
