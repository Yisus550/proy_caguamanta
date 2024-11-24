using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models
{
	public class MaterialesList
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public decimal Precio { get; set; }
		[Required]
		public int Cantidad { get; set; }
		[Required]
		public decimal SubTotal { get; set; }


	}
}
