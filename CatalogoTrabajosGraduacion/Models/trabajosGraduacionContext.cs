using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatalogoTrabajosGraduacion.Models
{
    public partial class trabajosGraduacionContext : DbContext
    {
        public trabajosGraduacionContext()
        {
        }

        public trabajosGraduacionContext(DbContextOptions<trabajosGraduacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<TrabajosGraduacion> TrabajosGraduacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source=DESKTOP-769GIM4\\SQLEXPRESS; Initial Catalog=trabajosGraduacion; user id=sa; password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PK__carrera__7B19E791933982E5");

                entity.ToTable("carrera");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("carrera")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Facultad).HasColumnName("facultad");

                entity.HasOne(d => d.FacultadNavigation)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.Facultad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__carrera__faculta__286302EC");
            });

            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.HasKey(e => e.IdFacultad)
                    .HasName("PK__facultad__B57E5B20A7F5CE8E");

                entity.ToTable("facultad");

                entity.Property(e => e.IdFacultad).HasColumnName("idFacultad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("facultad")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__tipo__BDD0DFE17533ACE7");

                entity.ToTable("tipo");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrabajosGraduacion>(entity =>
            {
                entity.HasKey(e => e.IdTrabajo)
                    .HasName("PK__trabajos__DDAA03FDB7571660");

                entity.ToTable("trabajosGraduacion");

                entity.Property(e => e.IdTrabajo).HasColumnName("idTrabajo");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasColumnName("autor")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Carrera).HasColumnName("carrera");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CarreraNavigation)
                    .WithMany(p => p.TrabajosGraduacion)
                    .HasForeignKey(d => d.Carrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajosG__carre__2B3F6F97");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.TrabajosGraduacion)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trabajosGr__tipo__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
