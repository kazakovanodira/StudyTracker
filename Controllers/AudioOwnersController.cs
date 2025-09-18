using Microsoft.AspNetCore.Mvc;
using StudyTracker.Interfaces;
using StudyTracker.Models.EFModels;

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
        {
            return BadRequest("Owner name is required");
        }
        
        var ownerExists = await _repo.GetByOwnerName(owner.OwnerName);

        if (ownerExists != null)
        {
            return BadRequest("This owner already exists.");
        }
        
        var created = await _repo.AddAsync(owner);
        return CreatedAtAction(nameof(GetAll), new { id = created.AudioOwnerId }, created);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var owners = await _repo.GetAllAsync();
        return Ok(owners);
    }
}