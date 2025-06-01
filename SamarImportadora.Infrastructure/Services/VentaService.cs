using AutoMapper;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Entities;
using SamarImportadora.Core.Interfaces;

namespace SamarImportadora.Infrastructure.Services;

public class VentaService : IVentaService
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IMapper _mapper;

    public VentaService(IVentaRepository ventaRepository, IMapper mapper)
    {
        _ventaRepository = ventaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VentaDto>> ObtenerVentasPorSucursalYFechaAsync(short sucursalId, DateTime fecha)
    {
        var ventas = await _ventaRepository.GetVentasPorSucursalYFechaAsync(sucursalId, fecha);
        return _mapper.Map<IEnumerable<VentaDto>>(ventas);
    }

    public async Task<IEnumerable<VentasSucursalMesDto>> GetVentasTotalesPorSucursalPorMesAsync()
    {
        var ventas = await _ventaRepository.GetVentasTotalesPorSucursalPorMesAsync();
        return _mapper.Map<IEnumerable<VentasSucursalMesDto>>(ventas);
    }
}