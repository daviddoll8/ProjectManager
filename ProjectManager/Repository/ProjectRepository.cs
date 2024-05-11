using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.Project;

namespace Repository;

public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    {
        
    }

    public async Task<List<Project>> GetAllProjectsAsync(bool trackChanges) => 
        await FindAll(trackChanges)
            .OrderBy(proj => proj.Name)
            .Include(proj => proj.Tags)
            .Include(proj => proj.Tasks)
            .ToListAsync();

    public async Task<Project?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
        /*return await _context.Project
            .Include(proj => proj.Tasks)
            .Include(proj => proj.Tags)
            .FirstOrDefaultAsync(proj => proj.Id == id);*/
    }

    public async Task<Project> CreateAsync(Project projectModel)
    {
        throw new NotImplementedException();
    }

    public async Task<Project?> UpdateAsync(Guid id, UpdateProjectRequestDto projectRequestDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Project?> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}