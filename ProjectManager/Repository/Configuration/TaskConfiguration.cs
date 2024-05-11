using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Enums;
using Task = Entities.Models.Task;

namespace Repository.Configuration;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasData(
            new Task
            {
                Id = new Guid("7833721a-f1a7-470c-bdbb-851738a2f903"),
                ProjectId = new Guid("017121a4-0357-4dde-9057-5030c19dd128"),
                Name = "Replace kitchen cabinets",
                Description = "Take down and replace kitchen cabinets",
                IsCompleted = false,
                Priority = TaskPriority.Low
            },
            new Task
            {
                Id = new Guid("8929d097-56c6-4439-b362-212ae2ecb8f9"),
                ProjectId = new Guid("ab29aef9-77c5-4654-8e19-12cde67ded9a"),
                Name = "Configure Authentication",
                Description = "Use firebase for authentication and set it up in the project",
                IsCompleted = false,
                Priority = TaskPriority.Medium
            }

        );
    }
}