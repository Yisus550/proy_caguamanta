using System.ComponentModel.DataAnnotations;

namespace caguamanta2._0.Models;

public partial class Compra
{
    [Key]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Id { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[DataType(DataType.Date)]
	public DateOnly FechaCompra { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int IdEmpleado { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int IdProveedor { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "El importe no debe de ser menor a $1")]
    public double Importe { get; set; }
}
