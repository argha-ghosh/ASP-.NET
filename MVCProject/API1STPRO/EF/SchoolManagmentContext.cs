using System;
using System.Collections.Generic;
using API1STPRO.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace API1STPRO.EF;

public partial class SchoolManagmentContext : DbContext
{
    public SchoolManagmentContext()
    {
    }

    public SchoolManagmentContext(DbContextOptions<SchoolManagmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.Property(e => e.CourseId).HasMaxLength(50);
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.CourseTeacher).HasMaxLength(50);

            entity.HasOne(d => d.Dept).WithMany(p => p.Courses)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Departments");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK_Departments_1");

            entity.Property(e => e.DeptCourses).HasMaxLength(50);
            entity.Property(e => e.DeptLocation).HasMaxLength(50);
            entity.Property(e => e.DeptName).HasMaxLength(50);
            entity.Property(e => e.DeptStudents).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Studensts");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.BloodGroup).HasMaxLength(50);
            entity.Property(e => e.Cgpa)
                .HasMaxLength(50)
                .HasColumnName("CGPA");
            entity.Property(e => e.DeptId).ValueGeneratedOnAdd();
            entity.Property(e => e.DeptName).HasMaxLength(50);
            entity.Property(e => e.StudenrtName).HasMaxLength(50);

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Departments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
