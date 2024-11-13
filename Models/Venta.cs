using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models
{
	public class Venta
	{
		[Key]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[DataType(DataType.Date)]
		public DateOnly FechaVenta { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		public int EmpleadoId { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		public int ClienteId { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Range(1, double.MaxValue, ErrorMessage = "La compora no debe de ser menor a $1")]
		public decimal Importe { get; set; }
	}
}
