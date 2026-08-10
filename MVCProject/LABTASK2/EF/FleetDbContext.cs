using System;
using System.Collections.Generic;
using LABTASK2.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace LABTASK2.EF;

public partial class FleetDbContext : DbContext
{
    public FleetDbContext()
    {
    }

    public FleetDbContext(DbContextOptions<FleetDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FuelLog> FuelLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FuelLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.Property(e => e.BusCode).HasMaxLength(50);
            entity.Property(e => e.CostPerLiter).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LittersFilled).HasMaxLength(50);
            entity.Property(e => e.Route).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
