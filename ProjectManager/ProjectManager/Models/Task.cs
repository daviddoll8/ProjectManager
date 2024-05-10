using ProjectManager.Enums;

namespace ProjectManager.Models;

public class Task
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public bool IsCompleted { get; set; }
    public TaskPriority? Priority { get; set; }
    public Project Project { get; set; } = null!;
}