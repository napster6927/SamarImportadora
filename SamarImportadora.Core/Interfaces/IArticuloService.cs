using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Entities; // Asegúrate de que este espacio de nombres sea correcto

namespace SamarImportadora.Core.Interfaces
{
    public interface IArticuloService
    {
        Task<bool> UpdateArticuloAsync(string codigo_producto, DTOs.ArticuloDto articuloDto);
        Task<Entities.Articulo?> GetByCodigoProducto(string codigo_producto);
    }
}
