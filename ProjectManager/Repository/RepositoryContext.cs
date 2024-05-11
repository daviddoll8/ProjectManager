using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Task = Entities.Models.Task;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) 
        : base(options)
    {
        
    }
    
    public DbSet<Project>? Project { get; set; }
    public DbSet<ProjectTag>? ProjectTags { get; set; }
    public DbSet<Task>? Tasks { get; set; }
    public DbSet<Tag>? Tag { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasMany(project => project.Tags)
            .WithMany(tag => tag.Projects)
            .UsingEntity<ProjectTag>();

        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectTagsConfiguration());
    }
}