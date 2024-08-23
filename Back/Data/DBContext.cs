using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back.Data;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SANTIAGO\\SQLEXPRESS;Database=pruebaTecnica;Trusted_Connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("productos");

            entity.Property(e => e.Calificacion)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("calificacion");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Imagen)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.TotalCalificaciones).HasColumnName("totalCalificaciones");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
