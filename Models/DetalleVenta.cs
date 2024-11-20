using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proy_caguamanta.Models;

public partial class DetalleVenta
{
	[Key]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Id { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Display(Name = "Venta")]
	[ForeignKey("Venta")]
	public int VentaId { get; set; }
	public Venta Venta { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Display(Name = "Producto")]
	[ForeignKey("Producto")]
	public int ProductoId { get; set; }
	public Producto producto { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "El precio no debe de ser menor a $1")]
	[Display(Name = "Precio Unidad")]
	public decimal PrecioUnidad { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, int.MaxValue, ErrorMessage = "La cantidad no debe de ser menor a 1")]
	[Display(Name = "Cantidad")]
	public int Cantidad { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "El importe no debe de ser menor a $1")]
	[Display(Name = "Importe")]
	public decimal Importe { get; set; }
}
