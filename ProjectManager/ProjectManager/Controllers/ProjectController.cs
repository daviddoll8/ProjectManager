using Microsoft.AspNetCore.Mvc;
using ProjectManager.Data;

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
        var projects = _context.Project.ToList();

        return Ok(projects);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var project = _context.Project.Find(id);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }
}