using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebPrantica1.Models;

public partial class DbVehiculoContext : DbContext
{
    public DbVehiculoContext()
    {
    }

    public DbVehiculoContext(DbContextOptions<DbVehiculoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

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

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PRIMARY");

            entity.ToTable("vehiculo");

            entity.Property(e => e.IdVehiculo).HasColumnType("int(11)");
            entity.Property(e => e.AñoFabricacion).HasColumnName("Año_fabricacion");
            entity.Property(e => e.Color).HasMaxLength(45);
            entity.Property(e => e.Marca).HasMaxLength(45);
            entity.Property(e => e.Modelo).HasMaxLength(45);
            entity.Property(e => e.Patente).HasMaxLength(45);
            entity.Property(e => e.Precio).HasColumnType("int(11)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
