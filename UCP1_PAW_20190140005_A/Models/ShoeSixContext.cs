using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_20190140005_A.Models
{
    public partial class ShoeSixContext : DbContext
    {
        public ShoeSixContext()
        {
        }

        public ShoeSixContext(DbContextOptions<ShoeSixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Casual> Casuals { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sporty> Sporties { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdSepatu);

                entity.ToTable("Admin");

                entity.Property(e => e.IdSepatu)
                    .ValueGeneratedNever()
                    .HasColumnName("id_sepatu");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Casual>(entity =>
            {
                entity.HasKey(e => e.IdSepatu);

                entity.ToTable("casual");

                entity.Property(e => e.IdSepatu)
                    .ValueGeneratedNever()
                    .HasColumnName("id_sepatu");

                entity.Property(e => e.BrandSepatu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("brand_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.HargaSepatu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("harga_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.JenisSepatu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("jenis_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.NamaSepatu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.StockSepatu).HasColumnName("stock_sepatu");

                entity.Property(e => e.UkuranSepatu)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ukuran_sepatu")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdSepatuNavigation)
                    .WithOne(p => p.Casual)
                    .HasForeignKey<Casual>(d => d.IdSepatu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_casual_Admin");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdSepatu);

                entity.ToTable("Customer");

                entity.Property(e => e.IdSepatu)
                    .ValueGeneratedNever()
                    .HasColumnName("id_sepatu");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdSepatuNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.IdSepatu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_casual");
            });

            modelBuilder.Entity<Sporty>(entity =>
            {
                entity.HasKey(e => e.IdSepatu);

                entity.ToTable("sporty");

                entity.Property(e => e.IdSepatu)
                    .ValueGeneratedNever()
                    .HasColumnName("id_sepatu");

                entity.Property(e => e.BrandSepatu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("brand_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.HargaSepatu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("harga_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.JenisSepatu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("jenis_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.NamaSepatu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_sepatu")
                    .IsFixedLength(true);

                entity.Property(e => e.StockSepatu).HasColumnName("stock_sepatu");

                entity.Property(e => e.UkuranSepatu)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ukuran_sepatu")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdSepatuNavigation)
                    .WithOne(p => p.Sporty)
                    .HasForeignKey<Sporty>(d => d.IdSepatu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sporty_Admin");

                entity.HasOne(d => d.IdSepatu1)
                    .WithOne(p => p.Sporty)
                    .HasForeignKey<Sporty>(d => d.IdSepatu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sporty_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
