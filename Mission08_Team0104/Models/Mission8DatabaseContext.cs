using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0104.Models;

public class Mission8DatabaseContext : DbContext
{
    public Mission8DatabaseContext(DbContextOptions<Mission8DatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home"},
            new Category { CategoryId = 2, CategoryName = "School"},
            new Category { CategoryId = 3, CategoryName = "Work"},
            new Category { CategoryId = 4, CategoryName = "Church"},
            new Category { CategoryId = 5, CategoryName = "Other"}
        );
    }
}