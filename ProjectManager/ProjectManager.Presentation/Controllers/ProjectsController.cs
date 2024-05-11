using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Entities.Mappers;
using Service.Contracts;
using Shared.DataTransferObjects.Project;

namespace ProjectManager.Presentation.Controllers;

[Route("api/Projects")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IServiceManager _service;
    
    public ProjectsController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await _service.ProjectService.GetAllProjects(trackChanges: false);
        
        return Ok(projects);
    }

    /*[HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var project = await _projectRepo.GetByIdAsync(id);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project.ToProjectDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectRequestDto projectRequestDto)
    {
        if (projectRequestDto.TagIds != null)
        {
            //check for non-existing id's
            var currentTags = await _context.Tag.Select(tag => tag.Id).ToListAsync();
            var nonExistingTagIds = projectRequestDto.TagIds
                .Except(currentTags)
                .ToList();
            if (nonExistingTagIds.Any())
            {
                return BadRequest($"Tag ID(s) {string.Join(", ", nonExistingTagIds)} do not exist in the database.");
            }
            //update the context to contain the Tag Ids that were added by the projectRequestDto
            await _context.Tag.Where(tag => projectRequestDto.TagIds.Contains(tag.Id)).LoadAsync();
        }

        var projectModel = projectRequestDto.ToProjectFromCreateDto();
        
        await _context.Project.AddAsync(projectModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = projectModel.Id }, projectModel.ToProjectDto());
    }

    [HttpPut]
    [Route("id:guid")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProjectRequestDto updateDto)
    {
        var projectModel = await _context.Project.FirstOrDefaultAsync(proj => proj.Id == id);

        if (projectModel == null)
        {
            return NotFound();
        }

        projectModel.Name = updateDto.Name;
        projectModel.Description = updateDto.Description;

        if (!updateDto.TagIds.IsNullOrEmpty())
        {
            var currentTags = await _context.Tag.Select(tag => tag.Id).ToListAsync();
            var nonExistingTagIds = updateDto.TagIds
                .Except(currentTags)
                .ToList();

            if (nonExistingTagIds.Any())
            {
                return BadRequest($"Tag ID(s) {string.Join(", ", nonExistingTagIds)} do not exist in the database.");
            }
            projectModel.ProjectTags ??= new List<ProjectTag>();
            projectModel.ProjectTags.Clear();
            projectModel.ProjectTags
                .AddRange(updateDto.TagIds.Select(tagId => new ProjectTag { ProjectId = id, TagId = tagId }));
        }
        
        var projTagsModel = await _context.ProjectTags.Where(projTag => projTag.ProjectId == id).ToListAsync();
        _context.ProjectTags.RemoveRange(projTagsModel);
        await _context.SaveChangesAsync();
        
        await _context.Tag.Where(tag => updateDto.TagIds != null && updateDto.TagIds.Contains(tag.Id)).LoadAsync();
        await _context.Tasks.Where(task => task.ProjectId == id).LoadAsync();
        return Ok(projectModel.ToProjectDto());
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var projectModel = await _context.Project.FirstOrDefaultAsync(proj => proj.Id == id);

        if (projectModel == null)
        {
            return NotFound();
        }

        _context.Project.Remove(projectModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }*/
    
    
}