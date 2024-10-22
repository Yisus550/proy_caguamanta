using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models;

public partial class Cliente
{
    [Key]
	[Required(ErrorMessage = "Este campo es obligatorio")]
	public int Id { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [StringLength(60, ErrorMessage = "La cadena de texto no puede sobrepasar los 60 caracteres")]
	[Display(Name = "Nombre")]
	public string Nombre { get; set; }

	[Required(ErrorMessage = "Este campo es requerido.")]
	[DataType(DataType.PhoneNumber)]
	[Display(Name = "Teléfono")]
	public string Telefono { get; set; }
}
