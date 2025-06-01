using System.ComponentModel.DataAnnotations;

namespace SamarImportadora.Core.DTOs;

public class VentaDto
{
    [Required]
    public string Documento { get; set; } = null!;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public String Fecha { get; set; } = null!;

    [Required]
    public string IdCliente { get; set; } = null!;
    
    [Required]
    public string TipoDocumento { get; set; } = null!;
    
    public short? IdVendedor { get; set; }
    public int? TotalNeto { get; set; }
    public int? Impuesto { get; set; }
    public int? TotalDocumento { get; set; }
    public short? SucursalId { get; set; }
    public string NombreVendedor { get; set; } = null!;
    //public List<DetalleVentaDto> Detalles { get; set; } = new();
}

public class DetalleVentaDto
{
    [Required]
    public string Documento { get; set; } = null!;
    
    [Required]
    public string CodigoProducto { get; set; } = null!;
    
    public string? NombreProducto { get; set; }
    public int? PrecioUnitario { get; set; }
    public int? Cantidad { get; set; }
    public int? Total { get; set; }
}