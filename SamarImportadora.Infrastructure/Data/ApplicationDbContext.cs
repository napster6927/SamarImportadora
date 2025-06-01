using Microsoft.EntityFrameworkCore;
using SamarImportadora.Core.Entities;
using SamarImportadora.Infrastructure.Data;

namespace SamarImportadora.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }

    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public DbSet<DetalleVenta> DetalleVenta { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Configuración para la entidad Venta
    modelBuilder.Entity<Venta>(entity =>
    {
        entity.ToTable("VENTAS");
        
        entity.Property(e => e.Documento)
            .HasColumnName("DOCUMENTO")
            .HasMaxLength(255);
        
        entity.Property(e => e.IdCliente)
            .HasColumnName("ID_CLIENTE")
            .HasMaxLength(255);
        
        entity.Property(e => e.TipoDocumento)
            .HasColumnName("TIPO_DOCUMENTO")
            .HasMaxLength(255);
        
        //entity.Property(e => e.Sucursal_Id)
          //  .HasColumnName("SUCURSAL_ID");

        entity.Property(e => e.IdVendedor)
      .HasColumnName("ID_VENDEDOR");
        // Configuración de la relación con DetalleVenta
        entity.HasMany(v => v.DetalleVenta)
            .WithOne(d => d.Venta)
            .HasForeignKey(d => d.Documento)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(v => v.Vendedor)
            .WithMany(v => v.Ventas)
            .HasForeignKey(v => v.IdVendedor)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(v => v.Sucursal)
            .WithMany(s => s.Ventas)
            .HasForeignKey(v => v.Sucursal_Id)
            .OnDelete(DeleteBehavior.Restrict);
    });

    // Configuración para la entidad Articulo
    modelBuilder.Entity<Articulo>(entity =>
    {
        entity.ToTable("ARTICULOS");
        
        entity.Property(e => e.CodigoProducto)
            .HasColumnName("CODIGO_PRODUCTO")
            .HasMaxLength(255);
        
        entity.Property(e => e.PrecioUnitario)
            .HasColumnName("PRECIO_UNITARIO");
        
        entity.Property(e => e.CostoUnitario)
            .HasColumnName("COSTO_UNITARIO");

        entity.Property(e => e.CodigoBarras)
            .HasColumnName("CODIGO_BARRAS");

        // Configuración de la relación con DetalleVenta
        entity.HasMany(a => a.DetalleVenta)
            .WithOne(d => d.Articulo)
            .HasForeignKey(d => d.CodigoProducto)
            .OnDelete(DeleteBehavior.Restrict);
    });

    // Configuración para la entidad DetalleVenta
    modelBuilder.Entity<DetalleVenta>(entity =>
    {
        entity.ToTable("DETALLE_VENTA");
        
        entity.Property(e => e.Documento)
            .HasColumnName("DOCUMENTO")
            .HasMaxLength(255);
        
        entity.Property(e => e.CodigoProducto)
            .HasColumnName("CODIGO_PRODUCTO")
            .HasMaxLength(255);
        
        entity.Property(e => e.PrecioUnitario)
            .HasColumnName("PRECIO_UNITARIO");
        
        entity.Property(e => e.Cantidad)
            .HasColumnName("CANTIDAD");

        // Clave primaria compuesta
        entity.HasKey(dv => new { dv.Documento, dv.CodigoProducto });
    });

    modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.ToTable("VENDEDORES");
            entity.Property(v => v.IdVendedor).HasColumnName("ID_VENDEDOR");
            entity.Property(v => v.Nombre).HasColumnName("NOMBRE");
            entity.Property(v => v.Apellido).HasColumnName("APELLIDO");
    });

    modelBuilder.Entity<Sucursal>(entity =>
    {
        entity.ToTable("SUCURSAL");
        entity.Property(s => s.Sucursal_Id).HasColumnName("SUCURSAL_ID");
        entity.Property(s => s.NombreSucursal).HasColumnName("NOMBRE_SUCURSAL");
    });

        base.OnModelCreating(modelBuilder);
}
}