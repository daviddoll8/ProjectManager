using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasData(
            new Project
            {
                Id = new Guid("017121a4-0357-4dde-9057-5030c19dd128"),
                Name = "Remodel Kitchen",
                Description = ""
            },
            new Project
            {
                Id = new Guid("ab29aef9-77c5-4654-8e19-12cde67ded9a"),
                Name = "Create ToDo Web API",
                Description = "Creating a web API with .NET Core"
            }
        );
    }
}