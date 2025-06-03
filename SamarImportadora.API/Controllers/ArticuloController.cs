// En SamarImportadora.API.Controllers.ArticulosController.cs
using Microsoft.AspNetCore.Mvc;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // Para logging

namespace SamarImportadora.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticulosController : ControllerBase
{
    private readonly IArticuloService _articuloService;
    private readonly ILogger<ArticulosController> _logger;

    public ArticulosController(IArticuloService articuloService, ILogger<ArticulosController> logger)
    {
        _articuloService = articuloService;
        _logger = logger;
    }

    /// <summary>
    /// Actualiza un artículo existente.
    /// </summary>
    /// <param name="codigo_producto">codigo_producto del artículo a actualizar.</param>
    /// <param name="articuloDto">Datos del artículo para actualizar.</param>
    /// <returns>NoContent si la actualización es exitosa, NotFound si el artículo no existe, o BadRequest en caso de error.</returns>
    [HttpPut("{codigo_producto}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateArticulo(string codigo_producto, [FromBody] ArticuloDto articuloDto)
    {
        if (articuloDto == null) // Validación básica
        {
            return BadRequest("El cuerpo de la solicitud no puede ser nulo.");
        }

        // Podrías agregar más validaciones aquí si es necesario usando ModelState

        try
        {
            _logger.LogInformation($"Intentando actualizar artículo con Codigo_producto: {codigo_producto}");
            var actualizado = await _articuloService.UpdateArticuloAsync(codigo_producto, articuloDto);

            if (!actualizado)
            {
                _logger.LogWarning($"No se encontró o no se pudo actualizar el artículo con Codigo_producto: {codigo_producto}");
                // Podrías diferenciar entre "no encontrado" y "fallo al actualizar" si el servicio lo permite
                return NotFound($"Artículo con Codigo_producto {codigo_producto} no encontrado o no se pudo actualizar.");
            }

            _logger.LogInformation($"Artículo con Codigo_producto: {codigo_producto} actualizado exitosamente.");
            return NoContent(); // Estándar para PUT/PATCH exitoso sin devolver contenido
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al actualizar el artículo con Codigo_producto: {codigo_producto}");
            return StatusCode(500, "Ocurrió un error interno al procesar la solicitud.");
        }
    }
}