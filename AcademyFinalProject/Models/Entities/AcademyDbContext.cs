using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcademyFinalProject.Models.Entities
{
    public partial class AcademyDbContext : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderToProduct> OrderToProduct { get; set; }
        public virtual DbSet<OrderToWork> OrderToWork { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Work> Work { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Phone).IsRequired();

                entity.Property(e => e.ProjectType).IsRequired();

                entity.Property(e => e.PropertyType).IsRequired();

                entity.Property(e => e.RequestedStartDate).HasColumnType("date");

                entity.Property(e => e.Street).IsRequired();

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.HasIndex(e => e.Cid)
                    .HasName("UQ__Order__C1F8DC58A77CE810")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.HasOne(d => d.C)
                    .WithOne(p => p.Order)
                    .HasForeignKey<Order>(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__CID__1B0907CE");
            });

            modelBuilder.Entity<OrderToProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.O)
                    .WithMany(p => p.OrderToProduct)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderToProd__OID__1BFD2C07");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.OrderToProduct)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderToProd__PID__1CF15040");
            });

            modelBuilder.Entity<OrderToWork>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HourlyRate).HasColumnType("money");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Wid).HasColumnName("WID");

                entity.HasOne(d => d.O)
                    .WithMany(p => p.OrderToWork)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderToWork__OID__1DE57479");

                entity.HasOne(d => d.W)
                    .WithMany(p => p.OrderToWork)
                    .HasForeignKey(d => d.Wid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderToWork__WID__1ED998B2");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.Category).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasKey(e => e.Wid);

                entity.Property(e => e.Wid).HasColumnName("WID");

                entity.Property(e => e.StandardHourlyRate).HasColumnType("money");

                entity.Property(e => e.Type).IsRequired();
            });
        }
    }
}
