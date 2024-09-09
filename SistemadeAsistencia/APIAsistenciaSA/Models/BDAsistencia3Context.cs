using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIAsistenciaSA.Models
{
    public partial class BDAsistencia3Context : DbContext
    {
        public BDAsistencia3Context()
        {
        }

        public BDAsistencia3Context(DbContextOptions<BDAsistencia3Context> options)
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
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:serverdebd1.database.windows.net,1433;Initial Catalog=BDAsistencia;Persist Security Info=False;User ID=idatuser;Password=19940269F4hi;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.Aluid);

                entity.ToTable("alumno");

                entity.Property(e => e.Aluid).HasColumnName("aluid");

                entity.Property(e => e.Aluestado).HasColumnName("aluestado");

                entity.Property(e => e.Apellidomat)
                    .IsRequired()
                    .HasColumnName("apellidomat")
                    .HasMaxLength(80);

                entity.Property(e => e.Apellidopat)
                    .IsRequired()
                    .HasColumnName("apellidopat")
                    .HasMaxLength(80);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasMaxLength(8);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Anoescolar>(entity =>
            {
                entity.HasKey(e => e.Aeid);

                entity.ToTable("anoescolar");

                entity.Property(e => e.Aeid).HasColumnName("aeid");

                entity.Property(e => e.Aeestado).HasColumnName("aeestado");

                entity.Property(e => e.Aefecfin)
                    .HasColumnName("aefecfin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Aefecini)
                    .HasColumnName("aefecini")
                    .HasColumnType("datetime");

                entity.Property(e => e.Aenombre)
                    .IsRequired()
                    .HasColumnName("aenombre")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Asistenciaalu>(entity =>
            {
                entity.HasKey(e => e.Fecid);

                entity.ToTable("asistenciaalu");

                entity.Property(e => e.Fecid).HasColumnName("fecid");

                entity.Property(e => e.Aluid).HasColumnName("aluid");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Fecano)
                    .HasColumnName("fecano")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fecestado).HasColumnName("fecestado");

                entity.Property(e => e.Marcacion)
                    .HasColumnName("marcacion")
                    .HasMaxLength(70);

                entity.HasOne(d => d.Alu)
                    .WithMany(p => p.Asistenciaalu)
                    .HasForeignKey(d => d.Aluid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK8");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Asistenciaalu)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK7");
            });

            modelBuilder.Entity<Asistenciadoc>(entity =>
            {
                entity.HasKey(e => e.Fdpid);

                entity.ToTable("asistenciadoc");

                entity.Property(e => e.Fdpid).HasColumnName("fdpid");

                entity.Property(e => e.Asmarca)
                    .HasColumnName("asmarca")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Fdpestado)
                    .IsRequired()
                    .HasColumnName("fdpestado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fdpfecha)
                    .HasColumnName("fdpfecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Hcid).HasColumnName("hcid");

                entity.Property(e => e.Marcamomento)
                    .HasColumnName("marcamomento")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Hc)
                    .WithMany(p => p.Asistenciadoc)
                    .HasForeignKey(d => d.Hcid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK6");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Curid);

                entity.ToTable("curso");

                entity.Property(e => e.Curid).HasColumnName("curid");

                entity.Property(e => e.Curestado).HasColumnName("curestado");

                entity.Property(e => e.Curnombre)
                    .IsRequired()
                    .HasColumnName("curnombre")
                    .HasMaxLength(120);

                entity.Property(e => e.Grdid).HasColumnName("grdid");

                entity.HasOne(d => d.Grd)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.Grdid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2");
            });

            modelBuilder.Entity<Cursodocente>(entity =>
            {
                entity.HasKey(e => new { e.Curid, e.Docid });

                entity.ToTable("cursodocente");

                entity.Property(e => e.Curid).HasColumnName("curid");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Cdfecasig)
                    .HasColumnName("cdfecasig")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Cur)
                    .WithMany(p => p.Cursodocente)
                    .HasForeignKey(d => d.Curid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK3");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Cursodocente)
                    .HasForeignKey(d => d.Docid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK4");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.Docid);

                entity.ToTable("docente");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Apellidomat)
                    .IsRequired()
                    .HasColumnName("apellidomat")
                    .HasMaxLength(70);

                entity.Property(e => e.Apellidopat)
                    .IsRequired()
                    .HasColumnName("apellidopat")
                    .HasMaxLength(70);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(8);

                entity.Property(e => e.Docestado).HasColumnName("docestado");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.Grdid);

                entity.ToTable("grado");

                entity.Property(e => e.Grdid).HasColumnName("grdid");

                entity.Property(e => e.Aeid).HasColumnName("aeid");

                entity.Property(e => e.Grdestado).HasColumnName("grdestado");

                entity.Property(e => e.Grdnombre)
                    .IsRequired()
                    .HasColumnName("grdnombre")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Ae)
                    .WithMany(p => p.Grado)
                    .HasForeignKey(d => d.Aeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1");
            });

            modelBuilder.Entity<Horariodoc>(entity =>
            {
                entity.HasKey(e => e.Hcid);

                entity.ToTable("horariodoc");

                entity.Property(e => e.Hcid).HasColumnName("hcid");

                entity.Property(e => e.Curid).HasColumnName("curid");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.Hcdia)
                    .IsRequired()
                    .HasColumnName("hcdia")
                    .HasMaxLength(20);

                entity.Property(e => e.Hchorafin).HasColumnName("hchorafin");

                entity.Property(e => e.Hchoraini).HasColumnName("hchoraini");

                entity.HasOne(d => d.Cursodocente)
                    .WithMany(p => p.Horariodoc)
                    .HasForeignKey(d => new { d.Curid, d.Docid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK5");
            });
        }
    }
}
