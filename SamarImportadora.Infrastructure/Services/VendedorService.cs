// En Infrastructure/Services/VendedorService.cs
using AutoMapper;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Entities;
using SamarImportadora.Core.Interfaces;

namespace SamarImportadora.Infrastructure.Services;

public class VendedorService : IVendedorService
{
    private readonly IVendedorRepository _repository;
    private readonly IMapper _mapper;

    public VendedorService(IVendedorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VendedorDto>> ObtenerTodosVendedoresAsync()
    {
        var vendedores = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<VendedorDto>>(vendedores);
    }
}