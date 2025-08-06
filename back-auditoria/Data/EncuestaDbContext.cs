using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using back_auditoria.Models;

namespace back_auditoria.Data;

public partial class EncuestaDbContext : DbContext
{
    public EncuestaDbContext()
    {
    }

    public EncuestaDbContext(DbContextOptions<EncuestaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditoria> Auditoria { get; set; }

    public virtual DbSet<Departamento> Departamento { get; set; }

    public virtual DbSet<Encuesta> Encuesta { get; set; }

    public virtual DbSet<Facultad> Facultad { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Pregunta> Pregunta { get; set; }

    public virtual DbSet<PreguntaEncuesta> PreguntaEncuesta { get; set; }

    public virtual DbSet<PreguntaItem> PreguntaItem { get; set; }

    public virtual DbSet<Reporte> Reporte { get; set; }

    public virtual DbSet<RespuestaItem> RespuestaItem { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Seccion> Seccion { get; set; }

    public virtual DbSet<Seguimiento> Seguimiento { get; set; }

    public virtual DbSet<Ubicacion> Ubicacion { get; set; }

    public virtual DbSet<UbicacionInstitucional> UbicacionInstitucional { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ROBERT;Database=EncuestaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria).HasName("PK__Auditori__7FD13FA0FCD3B456");

            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.IdUbicacionInstitucionalNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.IdUbicacionInstitucional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auditoria_UbicacionInstitucional");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DD1E30A6F");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.HasKey(e => e.IdEncuesta).HasName("PK__Encuesta__72579B54B37AD389");

            entity.HasOne(d => d.IdAuditoriaNavigation).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.IdAuditoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encuesta_Auditoria");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encuesta_Persona");
        });

        modelBuilder.Entity<Facultad>(entity =>
        {
            entity.HasKey(e => e.IdFacultad).HasName("PK__Facultad__443D4D5E2ADBF337");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PK__Item__51E84262D80BC2C4");

            entity.Property(e => e.Descripcion).HasMaxLength(200);

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.Item)
                .HasForeignKey(d => d.IdPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Pregunta");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__2EC8D2AC21964525");

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Persona)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Rol");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__754EC09EC7B62F02");

            entity.Property(e => e.Texto).HasMaxLength(300);

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pregunta_Seccion");
        });

        modelBuilder.Entity<PreguntaEncuesta>(entity =>
        {
            entity.HasKey(e => e.IdPreguntaEncuesta).HasName("PK__Pregunta__C0F5B9E4F25E7D94");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.PreguntaEncuesta)
                .HasForeignKey(d => d.IdEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaEncuesta_Encuesta");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.PreguntaEncuesta)
                .HasForeignKey(d => d.IdPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaEncuesta_Pregunta");
        });

        modelBuilder.Entity<PreguntaItem>(entity =>
        {
            entity.HasKey(e => e.IdPreguntaItem).HasName("PK__Pregunta__540E6D322065D936");

            entity.Property(e => e.Texto).HasMaxLength(300);

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.PreguntaItem)
                .HasForeignKey(d => d.IdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaItem_Item");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.PreguntaItem)
                .HasForeignKey(d => d.IdPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaItem_Pregunta");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__Reporte__F9561136F8922712");

            entity.Property(e => e.Detalles).HasMaxLength(4000);
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.IdSeguimientoNavigation).WithMany(p => p.Reporte)
                .HasForeignKey(d => d.IdSeguimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reporte_Seguimiento");
        });

        modelBuilder.Entity<RespuestaItem>(entity =>
        {
            entity.HasKey(e => e.IdRespuestaItem).HasName("PK__Respuest__EDF650CB6AE28A1E");

            entity.Property(e => e.PorcentajeCumplimiento).HasMaxLength(50);

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.RespuestaItem)
                .HasForeignKey(d => d.IdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RespuestaItem_Item");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CD47F1F37");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__Seccion__CD2B049F55BC0041");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__5643F60F4A15616D");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Evidencia).HasMaxLength(500);
            entity.Property(e => e.ObservacionEstado).HasMaxLength(500);
            entity.Property(e => e.ResponsableImplementacion).HasMaxLength(100);
            entity.Property(e => e.ResponsableTratamiento).HasMaxLength(100);
            entity.Property(e => e.Supervisor).HasMaxLength(100);

            entity.HasOne(d => d.IdRespuestaItemNavigation).WithMany(p => p.Seguimiento)
                .HasForeignKey(d => d.IdRespuestaItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimiento_RespuestaItem");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK__Ubicacio__778CAB1D13BCD9A0");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<UbicacionInstitucional>(entity =>
        {
            entity.HasKey(e => e.IdUbicacionInstitucional).HasName("PK__Ubicacio__C5E3930DEBC8F29B");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.UbicacionInstitucional)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UbicacionInstitucional_Departamento");

            entity.HasOne(d => d.IdFacultadNavigation).WithMany(p => p.UbicacionInstitucional)
                .HasForeignKey(d => d.IdFacultad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UbicacionInstitucional_Facultad");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.UbicacionInstitucional)
                .HasForeignKey(d => d.IdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UbicacionInstitucional_Ubicacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
