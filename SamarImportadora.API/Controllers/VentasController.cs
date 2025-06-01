using Microsoft.AspNetCore.Mvc;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Interfaces;
using SamarImportadora.Infrastructure.Services;

namespace SamarImportadora.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentasController : ControllerBase
{
    private readonly IVentaService _ventaService;
    private readonly ILogger<VentasController> _logger;

    public VentasController(IVentaService ventaService, ILogger<VentasController> logger)
    {
        _ventaService = ventaService;
        _logger = logger;
    }

    /// <summary>
    /// Obtiene las ventas de una sucursal en una fecha específica
    /// </summary>
    /// <param name="sucursalId">ID de la sucursal (ejemplo: 1, 2, etc.)</param>
    /// <param name="fecha">Fecha de las ventas (formato: yyyy-MM-dd)</param>
    /// <returns>Lista de ventas con sus detalles</returns>
    [HttpGet("sucursal/{sucursalId}/ventas/{fecha}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VentaDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<VentaDto>>> GetVentasPorSucursalYFecha(
        [FromRoute] short sucursalId,
        [FromRoute] DateTime fecha)
    {
        try
        {
            _logger.LogInformation($"Obteniendo ventas para sucursal {sucursalId} en la fecha {fecha:yyyy-MM-dd}");

            var ventas = await _ventaService.ObtenerVentasPorSucursalYFechaAsync(sucursalId, fecha);

            if (ventas == null || !ventas.Any())
            {
                _logger.LogWarning($"No se encontraron ventas para la sucursal {sucursalId} en la fecha {fecha:yyyy-MM-dd}");
                return NotFound();
            }

            return Ok(ventas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error al obtener ventas para sucursal {sucursalId} en la fecha {fecha:yyyy-MM-dd}");
            return StatusCode(500, "Ocurrió un error al procesar la solicitud");
        }
    }

    /// <summary>
    /// Obtiene las ventas totales por sucursal por mes
    /// </summary>
    /// <returns>Lista de ventas totales por sucursal por mes</returns>
    [HttpGet("ventas-totales-por-sucursal-por-mes")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VentasSucursalMesDto>))]
    public async Task<ActionResult<IEnumerable<VentasSucursalMesDto>>> GetVentasTotalesPorSucursalPorMes()
    {
        try
        {
            _logger.LogInformation("Obteniendo ventas totales por sucursal por mes");

            var ventas = await _ventaService.GetVentasTotalesPorSucursalPorMesAsync();

            if (ventas == null || !ventas.Any())
            {
                _logger.LogWarning("No se encontraron ventas totales por sucursal por mes");
                return NotFound();
            }

            return Ok(ventas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener ventas totales por sucursal por mes");
            return StatusCode(500, "Ocurrió un error al procesar la solicitud");
        }
    }

    
}