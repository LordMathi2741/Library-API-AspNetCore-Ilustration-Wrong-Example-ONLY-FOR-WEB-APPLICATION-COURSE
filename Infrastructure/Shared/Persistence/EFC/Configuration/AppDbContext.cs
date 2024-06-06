using Domain.Library.Model.Aggregates;
using Domain.Library.Model.ValueObjects;
using Infrastructure.Shared.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Shared.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            throw new Exception("Database is not configured");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().ToTable("books");
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
        modelBuilder.Entity<Book>().Property(b => b.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Description).IsRequired();
        modelBuilder.Entity<Book>().Property(b => b.Type).IsRequired();
        
      
        
        modelBuilder.UseSnakeCaseNamingConvention();
    }
    
    
}