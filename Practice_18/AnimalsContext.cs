using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practice_18;

public partial class AnimalsContext : DbContext
{
    string dbName = "animals.db";
    public AnimalsContext()
    {
    }

    public AnimalsContext(string dbName) : base()
    {
        this.dbName = dbName;
    }

    public AnimalsContext(DbContextOptions<AnimalsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<IAnimal> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"DataSource = {dbName}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MammalAnimal>(entity =>
        {
            entity.ToTable("animals");

            entity.HasIndex(e => e.Id, "IX_animals_Id").IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}