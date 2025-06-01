using SamarImportadora.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarImportadora.Core.Interfaces
{
    public interface IVendedorService
    {
        Task<IEnumerable<VendedorDto>> ObtenerTodosVendedoresAsync();
    }






}
