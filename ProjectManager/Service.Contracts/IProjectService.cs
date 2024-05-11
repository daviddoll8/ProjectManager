using Entities.Models;
using Shared.DataTransferObjects.Project;

namespace Service.Contracts;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllProjects(bool trackChanges);
}