using ProjectManager.Dtos.Tag;
using ProjectManager.Dtos.Task;

namespace ProjectManager.Dtos.Project;

public class ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public List<TaskDto> Tasks { get; set; }
    public List<TagDto> Tags { get; set; }
}