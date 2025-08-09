using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace front_auditoria.Models;

public partial class EncuestaDbContext : DbContext
{
    public EncuestaDbContext()
    {
    }

    public EncuestaDbContext(DbContextOptions<EncuestaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<EjecucionesEncuestum> EjecucionesEncuesta { get; set; }

    public virtual DbSet<Encuesta> Encuestas { get; set; }

    public virtual DbSet<EncuestasPregunta> EncuestasPreguntas { get; set; }

    public virtual DbSet<Facultade> Facultades { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<PreguntasItem> PreguntasItems { get; set; }

    public virtual DbSet<RespuestasItem> RespuestasItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seccione> Secciones { get; set; }

    public virtual DbSet<UbicacionesInstitucionale> UbicacionesInstitucionales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-0PURE6E;Database=EncuestaDB5;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__C225F98D01E97BEA");

            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__B49878C9CAA5B441");

            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<EjecucionesEncuestum>(entity =>
        {
            entity.HasKey(e => e.IdEjecucion).HasName("PK__Ejecucio__BC52C2F0461EE840");

            entity.Property(e => e.IdEjecucion).HasColumnName("idEjecucion");
            entity.Property(e => e.FechaEjecucion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaEjecucion");
            entity.Property(e => e.IdEncuesta).HasColumnName("idEncuesta");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.EjecucionesEncuesta)
                .HasForeignKey(d => d.IdEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ejecucion__idEnc__4BAC3F29");
        });

        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.HasKey(e => e.IdEncuesta).HasName("PK__Encuesta__C03F9857DA5BE2CE");

            entity.Property(e => e.IdEncuesta).HasColumnName("idEncuesta");
            entity.Property(e => e.IdEncuestaOrigen).HasColumnName("idEncuestaOrigen");
            entity.Property(e => e.IdUbicacionInstitucional).HasColumnName("idUbicacionInstitucional");

            entity.HasOne(d => d.IdEncuestaOrigenNavigation).WithMany(p => p.InverseIdEncuestaOrigenNavigation)
                .HasForeignKey(d => d.IdEncuestaOrigen)
                .HasConstraintName("FK__Encuestas__idEnc__47DBAE45");

            entity.HasOne(d => d.IdUbicacionInstitucionalNavigation).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.IdUbicacionInstitucional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encuestas__idUbi__46E78A0C");
        });

        modelBuilder.Entity<EncuestasPregunta>(entity =>
        {
            entity.HasKey(e => e.IdEncuestaPregunta).HasName("PK__Encuesta__978709E71FF2E340");

            entity.Property(e => e.IdEncuestaPregunta).HasColumnName("idEncuestaPregunta");
            entity.Property(e => e.IdEncuesta).HasColumnName("idEncuesta");
            entity.Property(e => e.IdPregunta).HasColumnName("idPregunta");

            entity.HasOne(d => d.IdEncuestaNavigation).WithMany(p => p.EncuestasPregunta)
                .HasForeignKey(d => d.IdEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encuestas__idEnc__534D60F1");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.EncuestasPregunta)
                .HasForeignKey(d => d.IdPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encuestas__idPre__5441852A");
        });

        modelBuilder.Entity<Facultade>(entity =>
        {
            entity.HasKey(e => e.IdFacultad).HasName("PK__Facultad__B57E5B20B16A565B");

            entity.Property(e => e.IdFacultad).HasColumnName("idFacultad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PK__Items__AD1942688076ECCC");

            entity.Property(e => e.IdItem).HasColumnName("idItem");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Personas__A47881416A269A7B");

            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.Rol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personas__Rol__398D8EEE");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__623EEC42FA6DE4FA");

            entity.Property(e => e.IdPregunta).HasColumnName("idPregunta");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Pregunta)
                .HasForeignKey(d => d.IdSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preguntas__idSec__5070F446");
        });

        modelBuilder.Entity<PreguntasItem>(entity =>
        {
            entity.HasKey(e => e.IdPreguntasItems).HasName("PK__Pregunta__8390D39FFD92F7A3");

            entity.Property(e => e.IdPreguntasItems).HasColumnName("idPreguntasItems");
            entity.Property(e => e.IdItem).HasColumnName("idItem");
            entity.Property(e => e.IdPregunta).HasColumnName("idPregunta");

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.PreguntasItems)
                .HasForeignKey(d => d.IdItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preguntas__idIte__59063A47");

            entity.HasOne(d => d.IdPreguntaNavigation).WithMany(p => p.PreguntasItems)
                .HasForeignKey(d => d.IdPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preguntas__idPre__59FA5E80");
        });

        modelBuilder.Entity<RespuestasItem>(entity =>
        {
            entity.HasKey(e => e.IdRespuestasItems).HasName("PK__Respuest__8D5B6DF1CFAD2164");

            entity.Property(e => e.IdRespuestasItems).HasColumnName("idRespuestasItems");
            entity.Property(e => e.IdEjecucion).HasColumnName("idEjecucion");
            entity.Property(e => e.IdPreguntasItems).HasColumnName("idPreguntasItems");
            entity.Property(e => e.PorcentajeCumplimiento).HasColumnName("porcentajeCumplimiento");
            entity.Property(e => e.Respuesta).HasColumnName("respuesta");

            entity.HasOne(d => d.IdEjecucionNavigation).WithMany(p => p.RespuestasItems)
                .HasForeignKey(d => d.IdEjecucion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__idEje__5DCAEF64");

            entity.HasOne(d => d.IdPreguntasItemsNavigation).WithMany(p => p.RespuestasItems)
                .HasForeignKey(d => d.IdPreguntasItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__idPre__5CD6CB2B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__3C872F760EC72052");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Seccione>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__Seccione__94B87A7C96202FD6");

            entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<UbicacionesInstitucionale>(entity =>
        {
            entity.HasKey(e => e.IdUbicacionInstitucional).HasName("PK__Ubicacio__686A1E0482919FF3");

            entity.Property(e => e.IdUbicacionInstitucional).HasColumnName("idUbicacionInstitucional");
            entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");
            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.IdFacultad).HasColumnName("idFacultad");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.UbicacionesInstitucionales)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ubicacion__idDep__440B1D61");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.UbicacionesInstitucionales)
                .HasForeignKey(d => d.IdDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ubicacion__idDir__4316F928");

            entity.HasOne(d => d.IdFacultadNavigation).WithMany(p => p.UbicacionesInstitucionales)
                .HasForeignKey(d => d.IdFacultad)
                .HasConstraintName("FK__Ubicacion__idFac__4222D4EF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
