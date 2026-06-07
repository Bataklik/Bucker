using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Bug> Bugs { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Bug>(entity => {
                entity.ToTable("Bugs");
                entity.HasKey(bug => bug.Id);
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}