using System.ComponentModel.DataAnnotations;
using proy_caguamanta.Enums;

namespace proy_caguamanta.Models
{
    public class Empleado
	{
		[Key]
		[Required(ErrorMessage = "Este campo es requerido.")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(30, ErrorMessage = "La cadena de texto no puede sobrepasar los 30 caracteres")]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; } 

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(30, ErrorMessage = "La cadena de texto no puede sobrepasar los 30 caracteres")]
		[Display(Name = "Apellido")]
		public string Apellido { get; set; }
		
		[Required(ErrorMessage = "Este campo es requerido.")]
		[EmailAddress]
		[Display(Name = "Correo Electrónico")]
		public string Correo { get; set; } //Login

		[Required(ErrorMessage = "Este campo es requerido.")]
		[DataType(DataType.Password)]
		[StringLength(20, ErrorMessage = "La cadena de texto no puede sobrepasar los 20 caracteres")]
		[Display(Name = "Contraseña")]
		public string Contrasena { get; set; } //Login

		[Required(ErrorMessage = "Este campo es requerido.")]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Teléfono")]
		public string Telefono { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(80, ErrorMessage = "La cadena de texto no puede sobrepasar los 80 caracteres")]
		[Display(Name = "Dirección")]
		public string Direccion { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(20, ErrorMessage = "La cadena de texto no puede sobrepasar los 20 caracteres")]
		[Display(Name = "Puesto")]
		public string Puesto { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[EnumDataType(typeof(EstadosUsuario))]
		[Display(Name = "Estado del usuario")]
		public string Estado { get; set; }
	}
}
