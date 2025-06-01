using System.Collections.Generic;
using System.Threading.Tasks;
using SamarImportadora.Core.DTOs;

namespace SamarImportadora.Core.Interfaces;

public interface IVentaService
{
    Task<IEnumerable<VentaDto>> ObtenerVentasPorSucursalYFechaAsync(short sucursalId, DateTime fecha); // Debe usar VentaDto
    Task<IEnumerable<VentasSucursalMesDto>> GetVentasTotalesPorSucursalPorMesAsync();
}