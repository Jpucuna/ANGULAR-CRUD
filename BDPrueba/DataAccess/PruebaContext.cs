using System;
using System.Collections.Generic;
using BDPrueba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BDPrueba.DataAccess
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Sector> Sectors { get; set; } = null!;
        public virtual DbSet<Zona> Zonas { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.CodPersona);

                entity.ToTable("persona");

                entity.Property(e => e.CodPersona).HasColumnName("cod_persona");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.CodZona).HasColumnName("cod_zona");

                entity.Property(e => e.FecNac)
                    .HasColumnType("date")
                    .HasColumnName("fec_nac");

                entity.Property(e => e.NomPersona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nom_persona");

                entity.Property(e => e.Sueldo).HasColumnName("sueldo");

                entity.HasOne(d => d.CodSectorNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodSector)
                    .HasConstraintName("FK_persona_sector");

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.CodZona)
                    .HasConstraintName("FK_persona_zona");
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.HasKey(e => e.CodSector);

                entity.ToTable("sector");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.DesSector)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("des_sector");
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.HasKey(e => e.CodZona);

                entity.ToTable("zona");

                entity.Property(e => e.CodZona).HasColumnName("cod_zona");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.DesZona)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("des_zona");

                entity.HasOne(d => d.CodSectorNavigation)
                    .WithMany(p => p.Zonas)
                    .HasForeignKey(d => d.CodSector)
                    .HasConstraintName("FK_zona_sector");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
