using Microsoft.AspNetCore.Mvc;
using StudyTracker.Interfaces;
using StudyTracker.Models.EFModels;

namespace StudyTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudyLogsController : ControllerBase
{
    private readonly IStudyLogRepository _repo;

    public StudyLogsController(IStudyLogRepository repo) => _repo = repo;

    [HttpPost]
    public async Task<IActionResult> AddStudyLog([FromBody] StudyLog log)
    {
        if (log == null)
        {
            return BadRequest("Invalid study log");
        }
        
        log.Id = Guid.NewGuid();
        log.Date = log.Date == default ? DateTime.UtcNow : log.Date;

        var created = await _repo.AddAsync(log);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var logs = await _repo.GetAllAsync();
        return Ok(logs);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var log = await _repo.GetById(id);
        return log is null ? NotFound() : Ok(log);
    }
}