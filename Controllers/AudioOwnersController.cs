using Microsoft.AspNetCore.Mvc;
using StudyTracker.Interfaces;
using StudyTracker.Models;

namespace StudyTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AudioOwnersController : ControllerBase
{
    private readonly IAudioOwnerRepository _repo;

    public AudioOwnersController(IAudioOwnerRepository repo) => _repo = repo;

    [HttpPost]
    public async Task<IActionResult> AddOwner([FromBody] AudioOwner owner)
    {
        if (string.IsNullOrWhiteSpace(owner.OwnerName))
            return BadRequest("Owner name is required");

        owner.OwnerId = Guid.NewGuid();

        var created = await _repo.AddAsync(owner);
        return CreatedAtAction(nameof(GetAll), new { id = created.OwnerId }, created);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var owners = await _repo.GetAllAsync();
        return Ok(owners);
    }
}