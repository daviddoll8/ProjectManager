using Microsoft.EntityFrameworkCore;
using ProjectManager.Models;
using Task = ProjectManager.Models.Task;

namespace ProjectManager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) 
        : base(options)
    {
        
    }
    
    public DbSet<Project> Project { get; set; }
    public DbSet<ProjectTag> ProjectTags { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Tag> Tag { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasMany(project => project.Tags)
            .WithMany(tag => tag.Projects)
            .UsingEntity<ProjectTag>();

    }
}