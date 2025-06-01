using AutoMapper;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Entities;

namespace SamarImportadora.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Venta, VentaDto>();
        CreateMap<DetalleVenta, DetalleVentaDto>()
            .ForMember(dest => dest.NombreProducto, 
                      opt => opt.MapFrom(src => src.Articulo.Nombre));
        CreateMap<Vendedor, VendedorDto>();
        CreateMap<VendedorDto, Vendedor>();
        CreateMap<Venta, VentaDto>()
            .ForMember(dest => dest.NombreVendedor,
                opt => opt.MapFrom(src =>
                    src.Vendedor != null ?
                    $"{src.Vendedor.Nombre.Trim()} {src.Vendedor.Apellido.Trim()}"
                    : "No asignado"))

            .ForMember(dest => dest.Fecha,
                opt => opt.MapFrom(src =>
                    src.Fecha.HasValue
                        ? src.Fecha.Value.ToString("yyyy-MM-dd")
                        : string.Empty));
    }
}