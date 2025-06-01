using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamarImportadora.Core.Entities;

public partial class DetalleVenta
{
    [Key]
    [StringLength(255)]
    public string Documento { get; set; } = null!;
    
    [Key]
    [StringLength(255)]
    public string CodigoProducto { get; set; } = null!;
    
    [Column("PRECIO_UNITARIO")]
    public int? PrecioUnitario { get; set; }
    
    [Column("CANTIDAD")]
    public int? Cantidad { get; set; }
    
    public int? Total { get; set; }

    [ForeignKey("CodigoProducto")]
    [InverseProperty("DetalleVenta")]
    public virtual Articulo Articulo { get; set; } = null!;

    [ForeignKey("Documento")]
    [InverseProperty("DetalleVenta")]
    public virtual Venta Venta { get; set; } = null!;
}