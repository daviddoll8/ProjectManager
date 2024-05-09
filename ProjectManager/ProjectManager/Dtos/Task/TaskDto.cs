using ProjectManager.Enums;

namespace ProjectManager.Dtos.Task;

public class TaskDto
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    
    public bool IsCompleted { get; set; }
    
    public TaskPriority Priority { get; set; }
}