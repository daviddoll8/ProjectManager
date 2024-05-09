using Microsoft.IdentityModel.Tokens;
using ProjectManager.Dtos.Project;
using ProjectManager.Models;

namespace ProjectManager.Mappers;

public static class ProjectMapper
{
    public static ProjectDto ToProjectDto(this Project projectModel)
    {
        return new ProjectDto()
        {
            Id = projectModel.Id,
            Name = projectModel.Name,
            Description = projectModel.Description,
            CreatedOn = projectModel.CreatedOn,
            Tasks = projectModel.Tasks.Select(task => task.ToTaskDto()).ToList(),
            Tags = projectModel.Tags.Select(tag => tag.ToTagDto()).ToList()
        };
    }

    public static Project ToProjectFromCreateDto(this CreateProjectRequestDto projectRequestDto)
    {
        var project = new Project()
        {
            Name = projectRequestDto.Name,
            Description = projectRequestDto.Description
        };

        if (!projectRequestDto.TagIds.IsNullOrEmpty())
        {
            project.ProjectTags = projectRequestDto.TagIds
                .Select(tagId => new ProjectTag() { ProjectId = project.Id, TagId = tagId })
                .ToList();
        }
        
        return project;
    }
}