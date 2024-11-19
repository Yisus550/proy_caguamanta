using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models
{
	public class Puesto
	{
		[Key]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[StringLength(20, ErrorMessage = "La cadena de texto no puede sobrepasar los 60 caracteres")]
		[Display(Name = "Nombre del puesto")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio")]
		[Range(1, double.MaxValue, ErrorMessage = "El sueldo no debe de ser menor a $1")]
		public decimal Sueldo { get; set; }

		//public List<Empleado> EmpleadoList { get; set; }
	}
}
