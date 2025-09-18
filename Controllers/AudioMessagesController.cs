using Microsoft.AspNetCore.Mvc;
using StudyTracker.Interfaces;
using StudyTracker.Models;
using StudyTracker.Models.EFModels;

namespace StudyTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AudioMessagesController : ControllerBase
{
    private readonly IAudioMessageRepository _repo;
    private readonly Random _random = new();

    public AudioMessagesController(IAudioMessageRepository repo) => _repo = repo;

    [HttpPost]
    public async Task<IActionResult> AddMessage([FromBody] AudioMessage audioMessage)
    {
        if (string.IsNullOrWhiteSpace(audioMessage.FilePath))
        {
            return BadRequest("File path is required");
        }
        
        var messageExists = await _repo.GetByMessageFilePath(audioMessage.FilePath);

        if (messageExists != null)
        {
            return BadRequest("This audioMessage already exists in the database.");
        }

        var created = await _repo.AddAsync(audioMessage);
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

        if (messages.Count == 0)
            return NotFound($"No audio messages found for category {category}");

        var randomMessage = messages.ElementAt(_random.Next(messages.Count));
        return Ok(randomMessage);
    }
    
    [HttpPut("{id}/filepath")]
    public async Task<IActionResult> UpdateFilePath(int id, [FromBody] UpdateFilePathDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FilePath))
        {
            return BadRequest("File path is required.");
        }

        var updated = await _repo.UpdateFilePathAsync(id, dto.FilePath);

        if (updated == null)
        {
            return NotFound($"AudioMessage with ID {id} not found.");
        }

        return Ok(updated);
    }
}