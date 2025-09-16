using Microsoft.AspNetCore.Mvc;
using StudyTracker.Interfaces;
using StudyTracker.Models;

namespace StudyTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AudioMessagesController : ControllerBase
{
    private readonly IAudioMessageRepository _repo;
    private readonly Random _random = new();

    public AudioMessagesController(IAudioMessageRepository repo) => _repo = repo;

    [HttpPost]
    public async Task<IActionResult> AddMessage([FromBody] AudioMessage message)
    {
        if (string.IsNullOrWhiteSpace(message.FilePath))
            return BadRequest("File path is required");

        message.AudioMessageId = Guid.NewGuid();

        var created = await _repo.AddAsync(message);
        return CreatedAtAction(nameof(GetByCategory), new { category = created.Category }, created);
    }

    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetByCategory(Category category)
    {
        var messages = await _repo.GetByCategory(category);
        return Ok(messages);
    }

    // 🔹 NEW ENDPOINT: Get a random audio message by category
    [HttpGet("random/{category}")]
    public async Task<IActionResult> GetRandomByCategory(Category category)
    {
        var messages = await _repo.GetByCategory(category);

        if (messages == null || messages.Count == 0)
            return NotFound($"No audio messages found for category {category}");

        var randomMessage = messages.ElementAt(_random.Next(messages.Count));
        return Ok(randomMessage);
    }
}