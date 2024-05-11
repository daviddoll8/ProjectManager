using Shared.DataTransferObjects.Tag;
using Shared.DataTransferObjects.Task;

namespace Shared.DataTransferObjects.Project;

public record ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<TaskDto>? Tasks { get; set; }
    public List<TagDto>? Tags { get; set; }
}