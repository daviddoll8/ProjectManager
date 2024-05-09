using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManager.Data;
using ProjectManager.Dtos.Project;
using ProjectManager.Mappers;

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
    public IActionResult GetAll()
    {
        var projects = _context.Project
            .Include(proj => proj.Tasks)
            .Include(proj => proj.Tags)
            .ToList()
            .Select(proj => proj.ToProjectDto());

        return Ok(projects);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var project = _context.Project
            .Include(proj => proj.Tasks)
            .Include(proj => proj.Tags)
            .FirstOrDefault(proj => proj.Id == id);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project.ToProjectDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProjectRequestDto projectRequestDto)
    {
        var nonExistingTagIds = projectRequestDto.TagIds
            .Except(_context.Tag.Select(tag => tag.Id))
            .ToList();
        if (nonExistingTagIds.Any())
        {
            return BadRequest($"Tag ID(s) {string.Join(", ", nonExistingTagIds)} do not exist in the database.");
        }
        
        var projectModel = projectRequestDto.ToProjectFromCreateDto();

        _context.Tag.Where(tag => projectRequestDto.TagIds.Contains(tag.Id)).Load();
        _context.Project.Add(projectModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = projectModel.Id }, projectModel.ToProjectDto());
    }
    
}