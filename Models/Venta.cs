using Microsoft.EntityFrameworkCore;
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
		public DateOnly FechaVenta { get; set; }
		
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Range(1, double.MaxValue, ErrorMessage = "La compora no debe de ser menor a $1")]
		public decimal Importe { get; set; }

		// relacion
			[Required(ErrorMessage = "Este campo es obligatorio")]
			// llave foranea
		[ForeignKey("Empleado")]	
		public int IdEmpleado { get; set; }
		// navegacion
		public Empleado Empleado { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		//llave foranea 
		[ForeignKey("Cliente")]
		public int IdCliente { get; set; }
		//navegacion
		public Cliente Cliente { get; set; }

		// relacion de 1:N
		public List<DetalleVenta> DetalleVentas { get; set; }
	}
}
