using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models
{
	public class Login
	{
		[Required(ErrorMessage = "Este campo es requerido.")]
		[EmailAddress]
		[Display(Name = "Correo Electrónico")]
		public string Correo { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[DataType(DataType.Password)]
		[StringLength(20, ErrorMessage = "La cadena de texto no puede sobrepasar los 20 caracteres")]
		[Display(Name = "Contraseña")]
		public string Contrasena { get; set; }

        public string Puesto { get; set; }
    }
}
