using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManager.Data;
using ProjectManager.Dtos.Project;
using ProjectManager.Mappers;
using ProjectManager.Models;

namespace ProjectManager.Controllers;

[Route("api/project")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    
    public ProjectController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _context.Project
            .Include(proj => proj.Tasks)
            .Include(proj => proj.Tags)
            .ToListAsync();
        
        var projectDto = projects.Select(proj => proj.ToProjectDto());

        return Ok(projectDto);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var project = await _context.Project
            .Include(proj => proj.Tasks)
            .Include(proj => proj.Tags)
            .FirstOrDefaultAsync(proj => proj.Id == id);

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
    }
    
    
}