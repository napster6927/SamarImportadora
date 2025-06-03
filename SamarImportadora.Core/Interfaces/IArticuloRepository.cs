// En SamarImportadora.Core.Interfaces.IArticuloRepository.cs
using SamarImportadora.Core.Entities;
using System.Threading.Tasks;

namespace SamarImportadora.Core.Interfaces;

public interface IArticuloRepository
{
    Task<Articulo?> GetByCodigoProductoAsync(string codigo_producto); // Usa el tipo de tu PK
    Task<bool> ExistsAsync(string codigo_producto); // Añadido para verificar la existencia del artículo
    Task<bool> UpdateArticuloAsync(Articulo articulo);
}