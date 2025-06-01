using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamarImportadora.Core.Entities;

public class Vendedor
{
    [Key]
    [Column("ID_VENDEDOR")]
    public short IdVendedor { get; set; }

    [Column("NOMBRE")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("APELLIDO")]
    [StringLength(100)]
    public string Apellido { get; set; } = null!;

    [InverseProperty("Vendedor")]
    public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

}