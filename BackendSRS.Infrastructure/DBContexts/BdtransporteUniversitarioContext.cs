using System;
using System.Collections.Generic;
using BackendSRS.Infrastructure.Models;
using BackendSRS.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BackendSRS.Infrastructure.DBContexts;

public partial class BdtransporteUniversitarioContext : DbContext
{
    public BdtransporteUniversitarioContext()
    {
    }

    public BdtransporteUniversitarioContext(DbContextOptions<BdtransporteUniversitarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alertas> Alertas { get; set; }

    public virtual DbSet<Condicionesclimaticas> Condicionesclimaticas { get; set; }

    public virtual DbSet<Dispositivos> Dispositivos { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    public virtual DbSet<Reportes> Reportes { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Videos> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=BDTransporteUniversitario;user=root;password=admin", ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Alertas>(entity =>
        {
            entity.HasKey(e => e.AlertaId).HasName("PRIMARY");

            entity.ToTable("alertas");

            entity.HasIndex(e => e.DispositivoId, "DispositivoID");

            entity.HasIndex(e => e.UsuarioId, "UsuarioID");

            entity.Property(e => e.AlertaId).HasColumnName("AlertaID");
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.EstadoAlerta).HasColumnType("enum('pendiente','resuelta')");
            entity.Property(e => e.FechaAlerta)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.TipoAlerta).HasColumnType("enum('batería baja','condición climática','atasco','otro')");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Alertas)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("alertas_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Alertas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("alertas_ibfk_2");
        });

        modelBuilder.Entity<Condicionesclimaticas>(entity =>
        {
            entity.HasKey(e => e.CondicionId).HasName("PRIMARY");

            entity.ToTable("condicionesclimaticas");

            entity.Property(e => e.CondicionId).HasColumnName("CondicionID");
            entity.Property(e => e.EstadoClima).HasColumnType("enum('despejado','lluvioso','ventoso','otro')");
            entity.Property(e => e.FechaCondicion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Temperatura).HasPrecision(5, 2);
            entity.Property(e => e.VelocidadViento).HasPrecision(5, 2);
        });

        modelBuilder.Entity<Dispositivos>(entity =>
        {
            entity.HasKey(e => e.DispositivoId).HasName("PRIMARY");

            entity.ToTable("dispositivos");

            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.Bateria).HasPrecision(5, 2);
            entity.Property(e => e.Estado).HasColumnType("enum('en uso','disponible','en mantenimiento')");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasColumnType("enum('robot','drone')");
            entity.Property(e => e.UbicacionActual).HasMaxLength(255);
            entity.Property(e => e.UltimaMantenimiento).HasColumnType("datetime");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.InventarioId).HasName("PRIMARY");

            entity.ToTable("inventario");

            entity.HasIndex(e => e.DispositivoId, "DispositivoID");

            entity.HasIndex(e => e.ProveedorId, "fk_inventario_proveedor");

            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.Componente).HasMaxLength(100);
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("inventario_ibfk_1");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("fk_inventario_proveedor");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.MantenimientoId).HasName("PRIMARY");

            entity.ToTable("mantenimientos");

            entity.HasIndex(e => e.DispositivoId, "DispositivoID");

            entity.Property(e => e.MantenimientoId).HasColumnName("MantenimientoID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.FechaMantenimiento).HasColumnType("datetime");
            entity.Property(e => e.KilometrajeHora).HasPrecision(10, 2);
            entity.Property(e => e.TipoMantenimiento).HasColumnType("enum('preventivo','correctivo')");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("mantenimientos_ibfk_1");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PRIMARY");

            entity.ToTable("reservas");

            entity.HasIndex(e => e.DispositivoId, "DispositivoID");

            entity.HasIndex(e => e.UsuarioId, "UsuarioID");

            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.Estado).HasColumnType("enum('confirmada','cancelada','completada')");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("reservas_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("reservas_ibfk_2");
        });

        modelBuilder.Entity<Reportes>(entity =>
        {
            entity.HasKey(e => e.ReporteId).HasName("PRIMARY");

            entity.ToTable("reportes");

            entity.HasIndex(e => e.AlertaId, "AlertaID");

            entity.HasIndex(e => e.DispositivoId, "DispositivoID");

            entity.HasIndex(e => e.ReservaId, "ReservaID");

            entity.HasIndex(e => e.UsuarioId, "UsuarioID");

            entity.Property(e => e.ReporteId).HasColumnName("ReporteID");

            entity.Property(e => e.AlertaId).HasColumnName("AlertaID");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");

            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");

            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");

            entity.Property(e => e.FechaReporte).HasColumnName("fecha_reporte");

            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");

            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");

            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.RolId, "RolID");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("usuarios_ibfk_1");
        });

        modelBuilder.Entity<Videos>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PRIMARY");

            entity.ToTable("videos");

            entity.HasIndex(e => e.DispositivoId, "DispositivoID");

            entity.Property(e => e.VideoId).HasColumnName("VideoID");
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.FechaGrabacion).HasColumnType("datetime");
            entity.Property(e => e.RutaVideo).HasMaxLength(255);
            entity.Property(e => e.Tipo).HasColumnType("enum('evento','recorrido')");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.Videos)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("videos_ibfk_1");
        });

        modelBuilder.Entity<Reportes>(entity =>
        {
            entity.HasKey(e => e.ReporteId).HasName("PRIMARY");

            entity.ToTable("reportes");

            entity.HasIndex(e => e.AlertaId, "AlertaID");

            entity.HasIndex(e => e.DispositivoId, "DispositivoID");

            entity.HasIndex(e => e.ReservaId, "ReservaID");

            entity.HasIndex(e => e.UsuarioId, "UsuarioID");

            entity.Property(e => e.ReporteId).HasColumnName("ReporteID");
            entity.Property(e => e.AlertaId).HasColumnName("AlertaID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.FechaReporte).HasColumnName("fecha_reporte");
            entity.Property(e => e.ReservaId).HasColumnName("ReservaID");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
