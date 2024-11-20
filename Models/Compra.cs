using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proy_caguamanta.Models;

public partial class Compra
{
    [Key]
    [Required(ErrorMessage = "Este campo es obligatorio")]
    public int? Id { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [DataType(DataType.Date)]
    public DateOnly? FechaCompra { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [ForeignKey("Empleado")]
    public int? EmpleadoId { get; set; }
    public Empleado Empleado { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [ForeignKey("Proveedor")]
    public int? ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }

    [Required(ErrorMessage = "Este campo es obligatorio")]
    [Range(1, double.MaxValue, ErrorMessage = "El importe no debe de ser menor a $1")]
    public double? Importe { get; set; }

    public List<DetalleCompra> compras { get; set; }
}
