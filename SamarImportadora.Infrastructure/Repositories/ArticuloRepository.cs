// En SamarImportadora.Infrastructure.Repositories.ArticuloRepository.cs
using Microsoft.EntityFrameworkCore;
using SamarImportadora.Core.Entities;
using SamarImportadora.Core.Interfaces;
using SamarImportadora.Infrastructure.Data; // Asegúrate que sea el DbContext correcto
using System.Threading.Tasks;

namespace SamarImportadora.Infrastructure.Repositories;

public class ArticuloRepository : IArticuloRepository
{
    private readonly ApplicationDbContext _context; // O InfrastructureDbContext si lo renombraste

    public ArticuloRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(string codigo_producto)
    {
        return await _context.Articulos
           .AnyAsync(a => a.Codigo_Producto == codigo_producto);
    }
    
    public async Task<Articulo?> GetByCodigoProductoAsync(string codigo_producto)
    {
        return await _context.Articulos
           .FirstOrDefaultAsync(a => a.Codigo_Producto == codigo_producto);
    }

  

    public async Task<bool> UpdateArticuloAsync(Articulo articulo)
    {
        _context.Entry(articulo).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            // Manejar concurrencia si es necesario, o simplemente relanzar/loggear
            // Podrías verificar si el artículo aún existe aquí.
            return false;
        }
        // Podrías capturar DbUpdateException para otros errores de BD
    }


 
}