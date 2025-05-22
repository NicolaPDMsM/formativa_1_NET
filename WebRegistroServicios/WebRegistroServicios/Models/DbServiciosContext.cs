using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebRegistroServicios.Models;

public partial class DbServiciosContext : DbContext
{
    public DbServiciosContext()
    {
    }

    public DbServiciosContext(DbContextOptions<DbServiciosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdClientes).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.IdClientes).HasColumnType("int(11)");
            entity.Property(e => e.Apellido).HasMaxLength(60);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(60);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicios).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.HasIndex(e => e.IdClientes, "fk_servicios_clientes_idx");

            entity.Property(e => e.IdServicios).HasColumnType("int(11)");
            entity.Property(e => e.Descripcion).HasMaxLength(45);
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_inicio");
            entity.Property(e => e.IdClientes).HasColumnType("int(11)");
            entity.Property(e => e.TipoServicios)
                .HasMaxLength(100)
                .HasColumnName("Tipo_servicios");
            entity.Property(e => e.Valor).HasColumnType("int(11)");

            entity.HasOne(d => d.IdClientesNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_servicios_clientes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
