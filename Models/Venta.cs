using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proy_caguamanta.Models
{
	public class Venta
	{
		[Key]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[DataType(DataType.Date)]
		public DateTime FechaVenta { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[ForeignKey("Empleado")]
		public int EmpleadoId { get; set; }
		public Empleado Empleado { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[ForeignKey("Cliente")]
		public int ClienteId { get; set; }
	    public Cliente Cliente { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Range(1, double.MaxValue, ErrorMessage = "La compora no debe de ser menor a $1")]
		public decimal Importe { get; set; }

		public List<DetalleVenta> ventas { get; set; }
	}
}
