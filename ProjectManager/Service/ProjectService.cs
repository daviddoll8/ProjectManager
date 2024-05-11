using Contracts;
using Entities.Mappers;
using Service.Contracts;
using Shared.DataTransferObjects.Project;

namespace Service;

internal sealed class ProjectService : IProjectService
{
    private readonly IRepositoryManager _repository;

    public ProjectService(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjects(bool trackChanges)
    {
        var projects = await _repository.Project.GetAllProjectsAsync(trackChanges);
        var projectDtos = projects.Select(proj => proj.ToProjectDto());
        
        return projectDtos;
    }
}