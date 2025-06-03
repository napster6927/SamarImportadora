using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SamarImportadora.Core.Entities;

public partial class SamarImportadoraContext : DbContext
{
    public SamarImportadoraContext()
    {
    }

    public SamarImportadoraContext(DbContextOptions<SamarImportadoraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<Vendedor> Vendedores { get; set; }

    public virtual DbSet<Sucursal> Sucursales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=FCH;Database=SamarImportadora;User ID=sa;Password=Eli79180582;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Codigo_Producto);

            entity.ToTable("ARTICULOS");

            entity.Property(e => e.Codigo_Producto)
                .HasMaxLength(255)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.Categoria)
                .HasMaxLength(255)
                .HasColumnName("CATEGORIA");
            entity.Property(e => e.CostoUnitario).HasColumnName("COSTO_UNITARIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.PrecioUnitario).HasColumnName("PRECIO_UNITARIO");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => new { e.Documento, e.CodigoProducto });
            
            entity.ToTable("DETALLE_VENTA");

            entity.Property(e => e.Documento)
                .HasMaxLength(255)
                .HasColumnName("DOCUMENTO");
                
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(255)
                .HasColumnName("CODIGO_PRODUCTO");

            entity.HasOne(d => d.Articulo)
                .WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Venta)
                .WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Documento)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Documento);

            entity.ToTable("VENTAS");

            entity.Property(e => e.Documento)
                .HasMaxLength(255)
                .HasColumnName("DOCUMENTO");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(255)
                .HasColumnName("ID_CLIENTE");
            entity.Property(e => e.IdVendedor).HasColumnName("ID_VENDEDOR");
            entity.Property(e => e.Impuesto).HasColumnName("IMPUESTO");
            entity.Property(e => e.Sucursal_Id).HasColumnName("SUCURSAL_ID");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(255)
                .HasColumnName("TIPO_DOCUMENTO");
            entity.Property(e => e.TotalDocumento).HasColumnName("TOTAL_DOCUMENTO");
            entity.Property(e => e.TotalNeto).HasColumnName("TOTAL_NETO");
            // Add relationships if they're not defined elsewhere
            entity.HasOne(e => e.Sucursal)
                .WithMany()
                .HasForeignKey(e => e.Sucursal_Id);

            entity.HasOne(e => e.Vendedor)
                .WithMany()
                .HasForeignKey(e => e.IdVendedor);
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.ToTable("VENDEDORES");
            entity.Property(v => v.IdVendedor).HasColumnName("ID_VENDEDOR");
            entity.Property(v => v.Nombre).HasColumnName("NOMBRE").HasMaxLength(100);
            entity.Property(v => v.Apellido).HasColumnName("APELLIDO").HasMaxLength(100);
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.ToTable("SUCURSAL");
            entity.HasKey(e => e.Sucursal_Id);
            entity.Property(e => e.Sucursal_Id).HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.NombreSucursal)
                .HasMaxLength(255)
                .HasColumnName("NOMBRE_SUCURSAL");
        });

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
