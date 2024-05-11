using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Project;

public record UpdateProjectRequestDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Guid>? TagIds { get; set; }
}