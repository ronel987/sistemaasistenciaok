using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sasistencia80.Models;

public partial class BdasistenciaContext : DbContext
{
    public BdasistenciaContext()
    {
    }

    public BdasistenciaContext(DbContextOptions<BdasistenciaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumno { get; set; }

    public virtual DbSet<Anoescolar> Anoescolar { get; set; }

    public virtual DbSet<Asistenciaalu> Asistenciaalu { get; set; }

    public virtual DbSet<Asistenciadoc> Asistenciadoc { get; set; }

    public virtual DbSet<Curso> Curso { get; set; }

    public virtual DbSet<Cursodocente> Cursodocente { get; set; }

    public virtual DbSet<Docente> Docente { get; set; }

    public virtual DbSet<Grado> Grado { get; set; }

    public virtual DbSet<Horariodoc> Horariodoc { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:serverdebd1.database.windows.net,1433;Initial Catalog=BDAsistencia;Persist Security Info=False;User ID=idatuser;Password=19940269F4hi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Aluid).HasName("alumno_pk");

            entity.ToTable("alumno");

            entity.Property(e => e.Aluid).HasColumnName("aluid");
            entity.Property(e => e.Aluestado).HasColumnName("aluestado");
            entity.Property(e => e.Apellidomat)
                .HasMaxLength(80)
                .HasColumnName("apellidomat");
            entity.Property(e => e.Apellidopat)
                .HasMaxLength(80)
                .HasColumnName("apellidopat");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<Anoescolar>(entity =>
        {
            entity.HasKey(e => e.Aeid).HasName("ano_pk");

            entity.ToTable("anoescolar");

            entity.Property(e => e.Aeid).HasColumnName("aeid");
            entity.Property(e => e.Aeestado).HasColumnName("aeestado");
            entity.Property(e => e.Aefecfin)
                .HasColumnType("datetime")
                .HasColumnName("aefecfin");
            entity.Property(e => e.Aefecini)
                .HasColumnType("datetime")
                .HasColumnName("aefecini");
            entity.Property(e => e.Aenombre)
                .HasMaxLength(4)
                .HasColumnName("aenombre");
        });

        modelBuilder.Entity<Asistenciaalu>(entity =>
        {
            entity.HasKey(e => e.Fecid).HasName("fecha_pk");

            entity.ToTable("asistenciaalu");

            entity.Property(e => e.Fecid).HasColumnName("fecid");
            entity.Property(e => e.Aluid).HasColumnName("aluid");
            entity.Property(e => e.Docid).HasColumnName("docid");
            entity.Property(e => e.Fecano)
                .HasColumnType("datetime")
                .HasColumnName("fecano");
            entity.Property(e => e.Fecestado).HasColumnName("fecestado");
            entity.Property(e => e.Marcacion)
                .HasMaxLength(70)
                .HasColumnName("marcacion");

            entity.HasOne(d => d.Alu).WithMany(p => p.Asistenciaalus)
                .HasForeignKey(d => d.Aluid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK8");

            entity.HasOne(d => d.Doc).WithMany(p => p.Asistenciaalus)
                .HasForeignKey(d => d.Docid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK7");
        });

        modelBuilder.Entity<Asistenciadoc>(entity =>
        {
            entity.HasKey(e => e.Fdpid).HasName("fdp_pk");

            entity.ToTable("asistenciadoc");

            entity.Property(e => e.Fdpid).HasColumnName("fdpid");
            entity.Property(e => e.Asmarca)
                .HasDefaultValue(false)
                .HasColumnName("asmarca");
            entity.Property(e => e.Fdpestado)
                .HasDefaultValue(true)
                .HasColumnName("fdpestado");
            entity.Property(e => e.Fdpfecha)
                .HasColumnType("datetime")
                .HasColumnName("fdpfecha");
            entity.Property(e => e.Hcid).HasColumnName("hcid");
            entity.Property(e => e.Marcamomento)
                .HasColumnType("datetime")
                .HasColumnName("marcamomento");

            entity.HasOne(d => d.Hc).WithMany(p => p.Asistenciadocs)
                .HasForeignKey(d => d.Hcid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK6");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Curid).HasName("curso_pk");

            entity.ToTable("curso");

            entity.Property(e => e.Curid).HasColumnName("curid");
            entity.Property(e => e.Curestado).HasColumnName("curestado");
            entity.Property(e => e.Curnombre)
                .HasMaxLength(120)
                .HasColumnName("curnombre");
            entity.Property(e => e.Grdid).HasColumnName("grdid");

            entity.HasOne(d => d.Grd).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.Grdid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2");
        });

        modelBuilder.Entity<Cursodocente>(entity =>
        {
            entity.HasKey(e => new { e.Curid, e.Docid }).HasName("curdoc_pk");

            entity.ToTable("cursodocente");

            entity.Property(e => e.Curid).HasColumnName("curid");
            entity.Property(e => e.Docid).HasColumnName("docid");
            entity.Property(e => e.Cdfecasig)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("cdfecasig");

            entity.HasOne(d => d.Cur).WithMany(p => p.Cursodocentes)
                .HasForeignKey(d => d.Curid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK3");

            entity.HasOne(d => d.Doc).WithMany(p => p.Cursodocentes)
                .HasForeignKey(d => d.Docid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK4");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.Docid).HasName("docente_pk");

            entity.ToTable("docente");

            entity.Property(e => e.Docid).HasColumnName("docid");
            entity.Property(e => e.Apellidomat)
                .HasMaxLength(70)
                .HasColumnName("apellidomat");
            entity.Property(e => e.Apellidopat)
                .HasMaxLength(70)
                .HasColumnName("apellidopat");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .HasColumnName("dni");
            entity.Property(e => e.Docestado).HasColumnName("docestado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Genero).HasColumnName("genero");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.Grdid).HasName("grado_pk");

            entity.ToTable("grado");

            entity.Property(e => e.Grdid).HasColumnName("grdid");
            entity.Property(e => e.Aeid).HasColumnName("aeid");
            entity.Property(e => e.Grdestado).HasColumnName("grdestado");
            entity.Property(e => e.Grdnombre)
                .HasMaxLength(50)
                .HasColumnName("grdnombre");

            entity.HasOne(d => d.Ae).WithMany(p => p.Grados)
                .HasForeignKey(d => d.Aeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1");
        });

        modelBuilder.Entity<Horariodoc>(entity =>
        {
            entity.HasKey(e => e.Hcid).HasName("hora_pk");

            entity.ToTable("horariodoc");

            entity.Property(e => e.Hcid).HasColumnName("hcid");
            entity.Property(e => e.Curid).HasColumnName("curid");
            entity.Property(e => e.Docid).HasColumnName("docid");
            entity.Property(e => e.Hcdia)
                .HasMaxLength(20)
                .HasColumnName("hcdia");
            entity.Property(e => e.Hchorafin).HasColumnName("hchorafin");
            entity.Property(e => e.Hchoraini).HasColumnName("hchoraini");

            entity.HasOne(d => d.Cursodocente).WithMany(p => p.Horariodocs)
                .HasForeignKey(d => new { d.Curid, d.Docid })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
