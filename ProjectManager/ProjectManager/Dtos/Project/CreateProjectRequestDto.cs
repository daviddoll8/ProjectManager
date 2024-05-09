namespace ProjectManager.Dtos.Project;

public class CreateProjectRequestDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Guid>? TagIds { get; set; }
}