using System.ComponentModel.DataAnnotations;
using proy_caguamanta.Enums;

namespace proy_caguamanta.Models
{
    public class Usuario
	{
		[Required(ErrorMessage = "Este campo es requerido.")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(30)]
		[Display(Name = "Nombre")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(30)]
		[Display(Name = "Apellido")]
		public string Apellido { get; set; }
		
		[Required(ErrorMessage = "Este campo es requerido.")]
		[EmailAddress]
		[Display(Name = "Correo Electrónico")]
		public string Correo { get; set; } //Login

		[Required(ErrorMessage = "Este campo es requerido.")]
		[DataType(DataType.Password)]
		[StringLength(20)]
		[Display(Name = "Contraseña")]
		public string Contrasena { get; set; } //Login

		[Required(ErrorMessage = "Este campo es requerido.")]
		[DataType(DataType.PhoneNumber)]
		[Display(Name = "Teléfono")]
		public string Telefono { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(80)]
		[Display(Name = "Dirección")]
		public string Direccion { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[StringLength(20)]
		[Display(Name = "Rol")]
		[EnumDataType(typeof(RolesUsuario))]
		public string Rol { get; set; }

		[Required(ErrorMessage = "Este campo es requerido.")]
		[EnumDataType(typeof(EstadosUsuario))]
		[Display(Name = "Estado del usuario")]
		public string Estado { get; set; }
	}
}
