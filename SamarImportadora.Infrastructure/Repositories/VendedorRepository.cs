// En Infrastructure/Repositories/VendedorRepository.cs
using Microsoft.EntityFrameworkCore;
using SamarImportadora.Core.Entities;
using SamarImportadora.Core.Interfaces;
using SamarImportadora.Infrastructure.Data;

namespace SamarImportadora.Infrastructure.Repositories;

public class VendedorRepository : IVendedorRepository
{
    private readonly ApplicationDbContext _context;

    public VendedorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vendedor>> GetAllAsync()
    {
        return await _context.Vendedores
            .AsNoTracking()
            .ToListAsync();
    }
}