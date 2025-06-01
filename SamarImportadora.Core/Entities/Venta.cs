using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamarImportadora.Core.Entities;

public partial class Venta
{
    [Key]
    [StringLength(255)]
    public string Documento { get; set; } = null!;
    
    public DateTime? Fecha { get; set; }
    
    [Column("ID_CLIENTE")]
    [StringLength(255)]
    public string IdCliente { get; set; } = null!;
    
    [Column("TIPO_DOCUMENTO")]
    [StringLength(255)]
    public string TipoDocumento { get; set; } = null!;
    
    [Column("ID_VENDEDOR")]
    public short IdVendedor { get; set; }
    
    [Column("TOTAL_NETO")]
    public int? TotalNeto { get; set; }
    
    [Column("IMPUESTO")]
    public int? Impuesto { get; set; }
    
    [Column("TOTAL_DOCUMENTO")]
    public int? TotalDocumento { get; set; }
    
    [Column("SUCURSAL_ID")]
    public short? Sucursal_Id { get; set; }
    
    [ForeignKey("Sucursal_Id")]
    public virtual Sucursal? Sucursal { get; set; }

    [InverseProperty("Venta")]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

   [ForeignKey("IdVendedor")]
    public virtual Vendedor Vendedor { get; set; } = null!;
}