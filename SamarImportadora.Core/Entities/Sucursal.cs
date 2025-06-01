using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SamarImportadora.Core.Entities
{
    [Table("SUCURSAL")]
    public class Sucursal
    {
        [Key]
        [Column("ID_SUCURSAL")]
        public short Sucursal_Id { get; set; }

        [Column("NOMBRE_SUCURSAL")]
        [StringLength(255)]
        public string NombreSucursal { get; set; } = null!;

        // Si tienes relación con ventas:
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}