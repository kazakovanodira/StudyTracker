using Microsoft.EntityFrameworkCore;
using StudyTracker.Context;
using StudyTracker.Interfaces;
using StudyTracker.Models.EFModels;

namespace StudyTracker.Repositories;

public class AudioOwnerRepository : IAudioOwnerRepository
{
    private readonly StudyContext _context;
    public AudioOwnerRepository(StudyContext context) => _context = context;

    public async Task<AudioOwner> AddAsync(AudioOwner owner)
    {
        _context.AudioOwners.Add(owner);
        await _context.SaveChangesAsync();
        return owner;
    }

    public async Task<ICollection<AudioOwner>> GetAllAsync()
    {
        return await _context.AudioOwners
            .Include(o => o.AudioMessages)
            .ToListAsync();
    }
}