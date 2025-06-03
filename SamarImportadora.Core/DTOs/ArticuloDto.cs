// En SamarImportadora.Core.DTOs.ArticuloUpdateDto.cs
namespace SamarImportadora.Core.DTOs;

public class ArticuloDto
{
    // No incluyas el ID aquí, se pasará por la ruta.
    // Solo los campos que se pueden actualizar.
    public string Codigo_Producto { get; set; } = null!; // Asegúrate de que no sea null, o maneja la validación en el controlador.
    public string Nombre { get; set; } = null!;
    public string Categoria { get; set; } = null!; // Asegúrate de que no sea null, o maneja la validación en el controlador.
    public int? PrecioUnitario { get; set; }
    public int? Costo_Unitario { get; set; }
    public string? Codigo_Barras { get; set; }    
    
    // Agrega otros campos que necesites actualizar
}