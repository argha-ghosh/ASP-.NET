using System;
using System.Collections.Generic;
using MVCProject.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.EF;

public partial class SchoolManagmentContext : DbContext
{
    public SchoolManagmentContext()
    {
    }

    public SchoolManagmentContext(DbContextOptions<SchoolManagmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dept> Depts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.Deptd);

            entity.Property(e => e.DeptName).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
