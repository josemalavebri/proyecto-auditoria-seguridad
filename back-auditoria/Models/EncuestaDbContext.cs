using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace auditoriaBackend.Models;

public partial class EncuestaDbContext : DbContext
{
    public EncuestaDbContext()
    {
    }

    public EncuestaDbContext(DbContextOptions<EncuestaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Encuestum> Encuesta { get; set; }

    public virtual DbSet<Facultad> Facultads { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<PreguntaEncuestum> PreguntaEncuesta { get; set; }

    public virtual DbSet<PreguntaItem> PreguntaItems { get; set; }

    public virtual DbSet<Preguntum> Pregunta { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<RespuestaItem> RespuestaItems { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Seccion> Seccions { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<UbicacionInstitucional> UbicacionInstitucionals { get; set; }
    private string cadenaJose = "Server=ROBERT;Database=EncuestaDB2;Trusted_Connection=True;TrustServerCertificate=True;";
    private string cadenaFalconi = "Server=DESKTOP-12H49JM;Database=EncuestaDB;Trusted_Connection=True;TrustServerCertificate=True;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(cadenaJose);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria).HasName("PK__Auditori__7FD13FA0361BFFFA");

            entity.HasOne(d => d.IdUbicacionInstitucionalNavigation).WithMany(p => p.Auditoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auditoria_UbicacionInstitucional");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433D13D6E224");
        });

        modelBuilder.Entity<Encuestum>(entity =>
        {
            entity.HasKey(e => e.IdEncuesta).HasName("PK__Encuesta__72579B54D5375313");

            entity.HasOne(d => d.IdAuditoriaNavigation).WithMany(p => p.Encuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encuesta_Auditoria");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Encuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Encuesta_Persona");
        });

        modelBuilder.Entity<Facultad>(entity =>
        {
            entity.HasKey(e => e.IdFacultad).HasName("PK__Facultad__443D4D5E5D21BFDD");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PK__Item__51E84262ABDE4491");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.Items)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Pregunta");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Persona__2EC8D2AC5C9B4BCD");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Persona_Rol");
        });

        modelBuilder.Entity<PreguntaEncuestum>(entity =>
        {
            entity.HasKey(e => e.IdPreguntaEncuesta).HasName("PK__Pregunta__C0F5B9E42E399DEA");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.PreguntaEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaEncuesta_Encuesta");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.PreguntaEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaEncuesta_Pregunta");
        });

        modelBuilder.Entity<PreguntaItem>(entity =>
        {
            entity.HasKey(e => e.IdPreguntaItem).HasName("PK__Pregunta__540E6D32896D5C4C");

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.PreguntaItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaItem_Item");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.PreguntaItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PreguntaItem_Pregunta");
        });

        modelBuilder.Entity<Preguntum>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__754EC09E5BE32946");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Pregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pregunta_Seccion");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.IdReporte).HasName("PK__Reporte__F9561136B12BA4B6");

            entity.HasOne(d => d.IdSeguimientoNavigation).WithMany(p => p.Reportes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reporte_Seguimiento");
        });

        modelBuilder.Entity<RespuestaItem>(entity =>
        {
            entity.HasKey(e => e.IdRespuestaItem).HasName("PK__Respuest__EDF650CB49C8E89C");

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.RespuestaItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RespuestaItem_Item");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CA4467A50");
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__Seccion__CD2B049F415AFF51");
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__5643F60FA555AE86");

            entity.HasOne(d => d.IdRespuestaItemNavigation).WithMany(p => p.Seguimientos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimiento_RespuestaItem");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK__Ubicacio__778CAB1D5EAB906F");
        });

        modelBuilder.Entity<UbicacionInstitucional>(entity =>
        {
            entity.HasKey(e => e.IdUbicacionInstitucional).HasName("PK__Ubicacio__C5E3930DF3AE2E1F");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.UbicacionInstitucionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UbicacionInstitucional_Departamento");

            entity.HasOne(d => d.IdFacultadNavigation).WithMany(p => p.UbicacionInstitucionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UbicacionInstitucional_Facultad");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.UbicacionInstitucionals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UbicacionInstitucional_Ubicacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
