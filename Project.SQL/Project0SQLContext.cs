using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project.SQL
{
    public partial class Project0SQLContext : DbContext
    {
        public Project0SQLContext()
        {
        }

        public Project0SQLContext(DbContextOptions<Project0SQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreLocation> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(160);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(160);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__73BA3083");

                entity.HasOne(d => d.StoreLocation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__StoreLoc__75A278F5");
            });

             modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "proj0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Produ__6FE99F9F");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreID)
                    .HasConstraintName("FK__Inventory__Store__70DDC3D8");
            });

             modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("OrderLine", "proj0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Order__71D1E811");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Produ__72C60C4A");
            });

            modelBuilder.Entity<Product>(entity =>
            {   
                entity.ToTable("Product");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(160);
            });

            modelBuilder.Entity<StoreLocation>(entity =>
            {
                entity.ToTable("Store");

                  entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
