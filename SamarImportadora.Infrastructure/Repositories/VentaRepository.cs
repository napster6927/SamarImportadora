using Microsoft.EntityFrameworkCore;
using SamarImportadora.Core.Entities;
using SamarImportadora.Core.Interfaces;
using SamarImportadora.Infrastructure.Data;

namespace SamarImportadora.Infrastructure.Repositories;

public class VentaRepository : IVentaRepository
{
    private readonly ApplicationDbContext _context;

    public VentaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Venta>> GetVentasPorSucursalYFechaAsync(short sucursalId, DateTime fecha)
    {
        return await _context.Ventas
                .Include(ve => ve.Vendedor)
                    .Include(v => v.DetalleVenta)
                        .ThenInclude(d => d.Articulo)
                            .Where(v => v.Sucursal_Id == sucursalId && 
                                       v.Fecha.HasValue && 
                                       v.Fecha.Value.Date == fecha.Date)
                            .OrderBy(v => v.Fecha)
                            .ToListAsync();
    }

    public async Task<IEnumerable<VentasSucursalMesDto>> GetVentasTotalesPorSucursalPorMesAsync()
    {
        return await _context.Ventas
        .Include(v => v.Sucursal)
        .Where(v => v.Fecha.HasValue && v.Sucursal != null)
        .GroupBy(v => new { 
            v.Sucursal_Id, 
            Mes = v.Fecha!.Value.Month,
            Anio = v.Fecha!.Value.Year,
            NombreSucursal = v.Sucursal != null ? v.Sucursal.NombreSucursal : string.Empty 
        })
        .Select(g => new VentasSucursalMesDto
        {
            Sucursal_Id = g.Key.Sucursal_Id ?? 0,
            NombreSucursal = g.Key.NombreSucursal,
            Mes = g.Key.Mes,
            Anio = g.Key.Anio,
            TotalVentas = (decimal)(g.Sum(v => v.TotalDocumento ?? 0))
        })
        .ToListAsync();
    }

}