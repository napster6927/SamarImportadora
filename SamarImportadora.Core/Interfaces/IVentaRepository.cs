using SamarImportadora.Core.Entities;

namespace SamarImportadora.Core.Interfaces;

public interface IVentaRepository
{
    Task<IEnumerable<Venta>> GetVentasPorSucursalYFechaAsync(short sucursalId, DateTime fecha);
    Task<IEnumerable<VentasSucursalMesDto>> GetVentasTotalesPorSucursalPorMesAsync(short sucursalId,DateTime fecha);

    
}