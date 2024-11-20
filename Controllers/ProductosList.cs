using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Controllers
{
	public class ProductosList
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public double Precio { get; set; }
		[Required]
		public int Cantidad { get; set; }
        [Required]
        public double SubTotal { get; set; }
    }
}