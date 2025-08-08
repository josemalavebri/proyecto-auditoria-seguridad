using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using front_auditoria.Models;

namespace front_auditoria.Data;

public partial class NombreDelContexto : DbContext
{
    public NombreDelContexto()
    {
    }

    public NombreDelContexto(DbContextOptions<NombreDelContexto> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamentos> Departamentos { get; set; }

    public virtual DbSet<Direcciones> Direcciones { get; set; }

    public virtual DbSet<Encuesta> Encuesta { get; set; }

    public virtual DbSet<EncuestasPreguntas> EncuestasPreguntas { get; set; }

    public virtual DbSet<Facultades> Facultades { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<ItemsPreguntas> ItemsPreguntas { get; set; }

    public virtual DbSet<Preguntas> Preguntas { get; set; }

    public virtual DbSet<RespuestaItem> RespuestaItem { get; set; }

    public virtual DbSet<Secciones> Secciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ROBERT;Database=EncuestaDB4;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamentos>(entity =>
        {
            entity.HasKey(e => e.idDepartamento).HasName("PK__Departam__C225F98D632718B8");

            entity.Property(e => e.nombre).HasMaxLength(255);

            entity.HasOne(d => d.idFacultadNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.idFacultad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departame__idFac__3C69FB99");
        });

        modelBuilder.Entity<Direcciones>(entity =>
        {
            entity.HasKey(e => e.idDireccion).HasName("PK__Direccio__B49878C9A733D495");

            entity.Property(e => e.nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Encuesta>(entity =>
        {
            entity.HasKey(e => e.idEncuesta).HasName("PK__Encuesta__C03F9857A8A0E4AC");

            entity.HasOne(d => d.idDepartamentoNavigation).WithMany(p => p.Encuesta)
                .HasForeignKey(d => d.idDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encuesta__idDepa__3F466844");
        });

        modelBuilder.Entity<EncuestasPreguntas>(entity =>
        {
            entity.HasKey(e => e.idEncuestaPregunta).HasName("PK__Encuesta__978709E78995DC84");

            entity.HasOne(d => d.idEncuestaNavigation).WithMany(p => p.EncuestasPreguntas)
                .HasForeignKey(d => d.idEncuesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encuestas__idEnc__46E78A0C");

            entity.HasOne(d => d.idPreguntaNavigation).WithMany(p => p.EncuestasPreguntas)
                .HasForeignKey(d => d.idPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encuestas__idPre__47DBAE45");
        });

        modelBuilder.Entity<Facultades>(entity =>
        {
            entity.HasKey(e => e.idFacultad).HasName("PK__Facultad__B57E5B2084CA5EC4");

            entity.Property(e => e.nombre).HasMaxLength(255);

            entity.HasOne(d => d.idDireccionNavigation).WithMany(p => p.Facultades)
                .HasForeignKey(d => d.idDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Facultade__idDir__398D8EEE");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.idItem).HasName("PK__Item__AD19426805CFB5CD");

            entity.Property(e => e.codigo).HasMaxLength(50);
            entity.Property(e => e.descripcion).HasMaxLength(500);
            entity.Property(e => e.titulo).HasMaxLength(255);
        });

        modelBuilder.Entity<ItemsPreguntas>(entity =>
        {
            entity.HasKey(e => e.idItemsPreguntas).HasName("PK__ItemsPre__C5DB83E46095167F");

            entity.HasOne(d => d.idItemNavigation).WithMany(p => p.ItemsPreguntas)
                .HasForeignKey(d => d.idItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemsPreg__idIte__4CA06362");

            entity.HasOne(d => d.idPreguntaNavigation).WithMany(p => p.ItemsPreguntas)
                .HasForeignKey(d => d.idPregunta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ItemsPreg__idPre__4D94879B");
        });

        modelBuilder.Entity<Preguntas>(entity =>
        {
            entity.HasKey(e => e.idPregunta).HasName("PK__Pregunta__623EEC42684E3164");

            entity.Property(e => e.descripcion).HasMaxLength(255);

            entity.HasOne(d => d.idSeccionNavigation).WithMany(p => p.Preguntas)
                .HasForeignKey(d => d.idSeccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Preguntas__idSec__440B1D61");
        });

        modelBuilder.Entity<RespuestaItem>(entity =>
        {
            entity.HasKey(e => e.idRespuestaItem).HasName("PK__Respuest__B77D05C823D3D85E");

            entity.HasOne(d => d.idItemNavigation).WithMany(p => p.RespuestaItem)
                .HasForeignKey(d => d.idItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__idIte__5070F446");
        });

        modelBuilder.Entity<Secciones>(entity =>
        {
            entity.HasKey(e => e.idSeccion).HasName("PK__Seccione__94B87A7C0A7C2F91");

            entity.Property(e => e.descripcion).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
