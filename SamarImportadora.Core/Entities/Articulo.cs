using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamarImportadora.Core.Entities;

public partial class Articulo
{
    [Key]
    [StringLength(255)]
    [Column("CODIGO_PRODUCTO")]
    public string Codigo_Producto { get; set; } = null!; // Inicialización agregada

    [StringLength(255)]
    public string? Nombre { get; set; }

    [StringLength(255)]
    public string? Categoria { get; set; } = null!; // Inicialización agregada

    [Column("PRECIO_UNITARIO")] // Mapear a nombre real de columna
    public int? PrecioUnitario { get; set; }

    [Column("COSTO_UNITARIO")]
    public int? CostoUnitario { get; set; }

    [Column("CODIGO_BARRAS")]
    public string? CodigoBarras { get; set; }

    [InverseProperty("Articulo")]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}