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
            .ForMember(dest => dest.Sucursal_Id, opt => opt.MapFrom(src => src.Sucursal_Id));
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

        CreateMap<ArticuloDto, Articulo>()
            .ForMember(dest => dest.Codigo_Producto, opt => opt.MapFrom(src => src.Codigo_Producto.Trim()))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre.Trim()))
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Trim())) // Corregido para usar Trim()
            .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.PrecioUnitario))
            .ForMember(dest => dest.CostoUnitario, opt => opt.MapFrom(src => src.Costo_Unitario))
            .ForMember(dest => dest.CodigoBarras, opt => opt.MapFrom(src => src.Codigo_Barras));
    }
}