using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class EventManagmentContext : DbContext
{
    public EventManagmentContext()
    {
    }

    public EventManagmentContext(DbContextOptions<EventManagmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    public virtual DbSet<VolunteerSkill> VolunteerSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventName).HasMaxLength(50);

            entity.HasOne(d => d.Org).WithMany(p => p.Events)
                .HasForeignKey(d => d.OrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Organizations");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrgId);

            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ContactEmail).HasMaxLength(50);
            entity.Property(e => e.OrgName).HasMaxLength(50);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.SkillName).HasMaxLength(50);
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<VolunteerSkill>(entity =>
        {
            entity.ToTable("VolunteerSkill");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.VolunteerEmail).HasMaxLength(50);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.VolunteerSkill)
                .HasForeignKey<VolunteerSkill>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VolunteerSkill_Skills");

            entity.HasOne(d => d.Id1).WithOne(p => p.VolunteerSkill)
                .HasForeignKey<VolunteerSkill>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VolunteerSkill_Volunteers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
