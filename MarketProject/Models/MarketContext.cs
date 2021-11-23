using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MarketProject.Models
{
    public partial class MarketContext : DbContext
    {
        public MarketContext()
        {
        }

        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Produk> Produks { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(50)
                    .HasColumnName("Nama_Admin");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.IdProduk);

                entity.ToTable("Produk");

                entity.Property(e => e.IdProduk)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Produk");

                entity.Property(e => e.HargaProduk)
                    .HasMaxLength(50)
                    .HasColumnName("Harga_Produk");

                entity.Property(e => e.JumlahProduk)
                    .HasMaxLength(50)
                    .HasColumnName("Jumlah_Produk");

                entity.Property(e => e.NamaProduk)
                    .HasMaxLength(50)
                    .HasColumnName("Nama_Produk");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Transaksi");

                entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");

                entity.Property(e => e.IdProduk).HasColumnName("Id_Produk");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.TanggalTransaksi).HasColumnName("Tanggal_Transaksi");

                entity.Property(e => e.TotalTransaksi)
                    .HasColumnType("money")
                    .HasColumnName("Total_Transaksi");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdAdmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_Admin");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdProduk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_Produk");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaksi_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_User");

                entity.Property(e => e.AlamatUser)
                    .HasMaxLength(50)
                    .HasColumnName("Alamat_User");

                entity.Property(e => e.NamaUser)
                    .HasMaxLength(50)
                    .HasColumnName("Nama_User");

                entity.Property(e => e.NomerTelpon)
                    .HasMaxLength(50)
                    .HasColumnName("Nomer_Telpon");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
