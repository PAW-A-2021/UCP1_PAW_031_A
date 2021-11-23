using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UCP1_PAW_031.Models;

#nullable disable

namespace UCP1_PAW_031.Models
{
    public partial class TraveloviaContext : DbContext
    {
        public TraveloviaContext()
        {
        }

        public TraveloviaContext(DbContextOptions<TraveloviaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BeachPlace> BeachPlaces { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserAccess> UserAccesses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BeachPlace>(entity =>
            {
                entity.HasKey(e => e.BeachId);

                entity.ToTable("Beach_Place");

                entity.Property(e => e.BeachId)
                    .ValueGeneratedNever()
                    .HasColumnName("Beach_id");

                entity.Property(e => e.BeachName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Beach_name");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity => 
            {
                entity.Property(e => e.DriverId)
                    .ValueGeneratedNever()
                    .HasColumnName("Driver_id");

                entity.ToTable("Driver");

                entity.Property(e => e.DriverName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Driver_name");

                entity.Property(e => e.DriverPhone)
                 .HasMaxLength(13)
                 .IsUnicode(false)
                .HasColumnName("Driver_phone");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("Payment_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_id");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Payment_Transaction");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Transaction_id");

                entity.Property(e => e.BeachId).HasColumnName("Beach_id");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId).HasColumnName("Driver_id");

                entity.Property(e => e.TanggalTransaksi)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_transaksi");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Postal_code");

                entity.Property(e => e.Price)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Beach)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.BeachId)
                    .HasConstraintName("FK_Transaction_Beach_Place1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Transaction_UserAccess");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_Transaction_Driver");
            });

            modelBuilder.Entity<UserAccess>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Register");

                entity.ToTable("UserAccess");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdCard)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Id_card");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
