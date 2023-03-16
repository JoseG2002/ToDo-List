using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Data.Models;

namespace ToDoListAPI.Data;

public partial class ToDoListDB : DbContext
{
    public ToDoListDB()
    {
    }

    public ToDoListDB(DbContextOptions<ToDoListDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Status> Status { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ToDoListDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC075905D1AA");

            entity.Property(e => e.StatusTask)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC07B363A79D");

            entity.Property(e => e.Description)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.FinishDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
