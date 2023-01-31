using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HeadacheInvSystem.Models
{
    public partial class ContolInventarioContext : DbContext
    {
        public ContolInventarioContext()
        {
        }

        public ContolInventarioContext(DbContextOptions<ContolInventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<ClientesProducto> ClientesProductos { get; set; } = null!;
        public virtual DbSet<Kardex> Kardices { get; set; } = null!;
        public virtual DbSet<OrdenVentum> OrdenVenta { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<ProveedorProducto> ProveedorProductos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-O8MTV2HT;Database=ContolInventario;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK_CategoriaID");

                entity.ToTable("Categoria", "Entrada");

                entity.Property(e => e.CategoriaId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CategoriaID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Categoria");
            });

            modelBuilder.Entity<ClientesProducto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ClientesProductos", "Salida");

                entity.Property(e => e.ClienteId).HasColumnName("ClienteID");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Cliente");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            });

            modelBuilder.Entity<Kardex>(entity =>
            {
                entity.ToTable("Kardex", "ControlM");

                entity.Property(e => e.KardexId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("KardexID");

                entity.Property(e => e.Compra).HasColumnType("decimal(22, 2)");

                entity.Property(e => e.CostoPromedio).HasColumnType("decimal(22, 2)");

                entity.Property(e => e.Debe).HasColumnType("decimal(22, 2)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Haber).HasColumnType("decimal(22, 2)");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.Property(e => e.Saldo).HasColumnType("decimal(22, 2)");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Kardices)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_ProductoID");
            });

            modelBuilder.Entity<OrdenVentum>(entity =>
            {
                entity.HasKey(e => e.OrdenId)
                    .HasName("PK_OrdenVenta_OrdenID");

                entity.ToTable("OrdenVenta", "Salida");

                entity.Property(e => e.OrdenId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OrdenID");

                entity.Property(e => e.ApellidoCliente)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Cliente");

                entity.Property(e => e.Correo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Cliente");

                entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.OrdenVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_ProductoID");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto", "Entrada");

                entity.Property(e => e.ProductoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductoID");

                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

                entity.Property(e => e.ProductoNombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Producto_Nombre");

                entity.Property(e => e.ProductoPrecioUnitario)
                    .HasColumnType("decimal(22, 2)")
                    .HasColumnName("Producto_Precio_Unitario");

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categoria_CategoriaID");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedor_ProveedorID");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor", "Entrada");

                entity.Property(e => e.ProveedorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProveedorID");

                entity.Property(e => e.Correo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProveedorProducto>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ProveedorProductos", "Entrada");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
