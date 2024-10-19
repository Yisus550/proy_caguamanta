using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models;

public partial class Material
{
    [Key]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int IdMaterial { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[StringLength(60, ErrorMessage = "La cadena de texto no puede sobrepasar los 60 caracteres")]
	[Display(Name = "Nombre del material")]
	public string Nombre { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, int.MaxValue, ErrorMessage = "La cantidad no debe de ser menor a 1")]
	[Display(Name = "Cantidad")]
	public int Cantidad { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[StringLength(60, ErrorMessage = "La cadena de texto no puede sobrepasar los 60 caracteres")]
	[Display(Name = "Proveedor")]
	public string Proveedor { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Range(1, double.MaxValue, ErrorMessage = "El costo no debe de ser menor a $1")]
	[Display(Name = "Costo")]
	public decimal Costo { get; set; }
}
