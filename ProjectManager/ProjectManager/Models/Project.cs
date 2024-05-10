namespace ProjectManager.Models;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public List<Task>? Tasks { get; set; } = new List<Task>();
    public List<Tag>? Tags { get; set; } = new List<Tag>();
    public List<ProjectTag>? ProjectTags { get; set; } = new List<ProjectTag>();
}