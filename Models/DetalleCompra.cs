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
	[ForeignKey("Compra")]
	public int CompraId { get; set; }
	public Compra Compra { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Display(Name = "Material")]
	[ForeignKey("Material")]
	public int MaterialId { get; set; }
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
