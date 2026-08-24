using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class ZeroHungerDbContext : DbContext
{
    public ZeroHungerDbContext()
    {
    }

    public ZeroHungerDbContext(DbContextOptions<ZeroHungerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CollectRequest> CollectRequests { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectRequest>(entity =>
        {
            entity.HasKey(e => e.CollectRequestId).HasName("PK__CollectR__D23592E3F115BC07");

            entity.Property(e => e.FoodDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PreserveUntil).HasColumnType("datetime");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Employee).WithMany(p => p.CollectRequests)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_CollectRequest_Employee");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.CollectRequests)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CollectRequest_Restaurant");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11893A64CD");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__87454C9565A7734C");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
