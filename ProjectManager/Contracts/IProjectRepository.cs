using Entities.Models;
using Shared.DataTransferObjects.Project;

namespace Contracts;

public interface IProjectRepository
{
    Task<List<Project>> GetAllProjectsAsync(bool trackChanges);
    Task<Project?> GetByIdAsync(Guid id);
    Task<Project> CreateAsync(Project projectModel);
    Task<Project?> UpdateAsync(Guid id, UpdateProjectRequestDto projectRequestDto);
    Task<Project?> DeleteAsync(Guid id);
}