using Microsoft.AspNetCore.Mvc;
using StudyTracker.Interfaces;
using StudyTracker.Models;

namespace StudyTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AudioMessagesController : ControllerBase
{
    private readonly IAudioMessageRepository _repo;

    public AudioMessagesController(IAudioMessageRepository repo) => _repo = repo;

    [HttpPost]
    public async Task<IActionResult> AddMessage([FromBody] AudioMessage message)
    {
        if (string.IsNullOrWhiteSpace(message.FilePath))
            return BadRequest("File path is required");

        message.AudioId = Guid.NewGuid();

        var created = await _repo.AddAsync(message);
        return CreatedAtAction(nameof(GetByCategory), new { category = created.Category }, created);
    }

    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetByCategory(Category category)
    {
        var messages = await _repo.GetByCategory(category);
        return Ok(messages);
    }
}