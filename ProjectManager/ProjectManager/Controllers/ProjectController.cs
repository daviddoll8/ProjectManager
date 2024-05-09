using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Data;
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
}