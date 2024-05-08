namespace ProjectManager.Models;

public class Tag
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<Project> Projects { get; set; } = null!;
    
    public List<ProjectTag> ProjectTags { get; set; } = null!;
}