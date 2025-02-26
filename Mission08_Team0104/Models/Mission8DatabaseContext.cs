using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0104.Models;

public class Mission8DatabaseContext : DbContext
{
    public Mission8DatabaseContext(DbContextOptions<Mission8DatabaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
}