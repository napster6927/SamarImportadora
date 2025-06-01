using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SamarImportadora.Core.DTOs;

public class VendedorDto
{
    public short IdVendedor { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Required]
    [StringLength(100)]
    public string Apellido { get; set; } = null!;
}