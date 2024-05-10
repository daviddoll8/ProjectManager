using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Dtos.Project;

public class UpdateProjectRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Guid>? TagIds { get; set; }
}