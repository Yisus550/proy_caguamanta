using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models;

public partial class Proveedor
{
	[Key]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Id { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[StringLength(60, ErrorMessage = "La cadena de texto no puede sobrepasar los 60 caracteres")]
	[Display(Name = "Nombre del proveedor")]
	public string Nombre { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[StringLength(60, ErrorMessage = "La cadena de texto no puede sobrepasar los 60 caracteres")]
	[Display(Name = "Apellido del proveedor")]
	public string Apellido { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[Phone]
	public string Telefono { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[EmailAddress]
	public string Correo { get; set; }

	[Required(ErrorMessage = "Este campo es obligatorio")]
	[StringLength(80)]
	[Display(Name = "Empresa")]
	public string Empresa { get; set; }

	public List<Compra> Compra { get; set; }
}
