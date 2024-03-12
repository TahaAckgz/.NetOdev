using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Odev.Models.Entities
{
    public partial class kitapdbContext : DbContext
    {
        public kitapdbContext()
        {
        }

        public kitapdbContext(DbContextOptions<kitapdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KitapTur> KitapTurs { get; set; } = null!;
        public virtual DbSet<Kitaplar> Kitaplars { get; set; } = null!;
        public virtual DbSet<Turler> Turlers { get; set; } = null!;
        public virtual DbSet<Yayinevleri> Yayinevleris { get; set; } = null!;
        public virtual DbSet<Yazarlar> Yazarlars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<KitapTur>(entity =>
            {
                entity.ToTable("kitap_tur");

                entity.HasIndex(e => e.KitapId, "kitap_id");

                entity.HasIndex(e => e.TurId, "tur_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KitapId).HasColumnName("kitap_id");

                entity.Property(e => e.TurId).HasColumnName("tur_id");

                entity.HasOne(d => d.Kitap)
                    .WithMany(p => p.KitapTurs)
                    .HasForeignKey(d => d.KitapId)
                    .HasConstraintName("FK_kitap_tur_kitaplar");

                entity.HasOne(d => d.Tur)
                    .WithMany(p => p.KitapTurs)
                    .HasForeignKey(d => d.TurId)
                    .HasConstraintName("FK_kitap_tur_turler");
            });

            modelBuilder.Entity<Kitaplar>(entity =>
            {
                entity.ToTable("kitaplar");

                entity.HasIndex(e => e.YayineviId, "yayinevi_id");

                entity.HasIndex(e => e.YazarId, "yazar_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasMaxLength(200)
                    .HasColumnName("ad")
                    .IsFixedLength();

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .HasColumnName("foto")
                    .IsFixedLength();

                entity.Property(e => e.Ozet)
                    .HasColumnType("text")
                    .HasColumnName("ozet");

                entity.Property(e => e.SayfaSayisi).HasColumnName("sayfa_sayisi");

                entity.Property(e => e.YayineviId).HasColumnName("yayinevi_id");

                entity.Property(e => e.YazarId).HasColumnName("yazar_id");

                entity.HasOne(d => d.Yayinevi)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.YayineviId)
                    .HasConstraintName("FK_kitaplar_yayinevleri");

                entity.HasOne(d => d.Yazar)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.YazarId)
                    .HasConstraintName("FK_kitaplar_yazarlar");
            });

            modelBuilder.Entity<Turler>(entity =>
            {
                entity.ToTable("turler");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasMaxLength(50)
                    .HasColumnName("ad")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Yayinevleri>(entity =>
            {
                entity.ToTable("yayinevleri");

                entity.HasIndex(e => e.Ad, "ad")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasMaxLength(100)
                    .HasColumnName("ad")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Yazarlar>(entity =>
            {
                entity.ToTable("yazarlar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad)
                    .HasMaxLength(50)
                    .HasColumnName("ad")
                    .IsFixedLength();

                entity.Property(e => e.Cinsiyet)
                    .HasMaxLength(5)
                    .HasColumnName("cinsiyet")
                    .IsFixedLength()
                    .HasComment("Kadın/Erkek K/E");

                entity.Property(e => e.DogumYeri)
                    .HasMaxLength(100)
                    .HasColumnName("dogum_yeri")
                    .IsFixedLength();

                entity.Property(e => e.DogumYili)
                    .HasColumnType("year")
                    .HasColumnName("dogum_yili");

                entity.Property(e => e.Soyad)
                    .HasMaxLength(50)
                    .HasColumnName("soyad")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
