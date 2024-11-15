using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models;
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
