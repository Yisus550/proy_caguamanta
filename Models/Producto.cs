using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models
{
	public class Producto
	{
		[Key]
		[Required(ErrorMessage = "Este campo es requerido.")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(30)]
		[Display(Name = "Nombre del producto")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(100)]
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
	}
}
