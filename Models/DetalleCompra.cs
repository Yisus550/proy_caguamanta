using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proy_caguamanta.Models;

public partial class DetalleCompra
{
	[Key]
	[Required(ErrorMessage = "Este campo es obligatorio")]
    public int Id { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Display(Name = "Compra")]
	// llave foranea
	[ForeignKey("Compra")]
	public int IdCompra { get; set; }
	// navegacion
	public Compra Compra { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Display(Name = "Producto")]
	// llave foranea
	[ForeignKey("Material")]
	public int IdProducto { get; set; }
	//navegacion
	public Material Material { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "El precio no debe de ser menor a $1")]
	[Display(Name = "Precio Unidad")]
	public decimal PrecioUnidad { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "La cantidad no debe de ser menor a 1")]
	[Display(Name = "Cantidad")]
	public int Cantidad { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "El importe no debe de ser menor a $1")]
	[Display(Name = "Importe")]
	public decimal Importe { get; set; }
}
