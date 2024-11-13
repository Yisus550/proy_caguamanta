using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proy_caguamanta.Models;

public partial class Compra
{
    [Key]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int? Id { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [DataType(DataType.Date)]
    public DateOnly? FechaCompra { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	// llave foranea
	[ForeignKey("Empleado")]
	public int IdEmpleado { get; set; }
	// navegacion
	public Empleado Empleado { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	// llave foranea
	[ForeignKey("Proveedor")]
	public int IdProveedor { get; set; }
	//navegacion
	public Proveedor Proveedor { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "El importe no debe de ser menor a $1")]
    public double Importe { get; set; }

	//relacion 1:N
	public List<DetalleCompra> DetalleCompra { get; set; }
}
