using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamarImportadora.Core.Entities;

namespace SamarImportadora.Core.Interfaces;

public interface IVendedorRepository
{
    Task<IEnumerable<Vendedor>> GetAllAsync();
}