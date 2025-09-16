using Microsoft.EntityFrameworkCore;
using StudyTracker.Context;
using StudyTracker.Interfaces;
using StudyTracker.Models;

namespace StudyTracker.Repositories;

public class AudioMessageRepository : IAudioMessageRepository
{
    private readonly StudyContext _context;
    public AudioMessageRepository(StudyContext context) => _context = context;

    public async Task<AudioMessage> AddAsync(AudioMessage audioMsg)
    {
        _context.AudioMessages.Add(audioMsg);
        await _context.SaveChangesAsync();
        return audioMsg;
    }

    public async Task<ICollection<AudioMessage>> GetByCategory(Category category)
    {
        return await _context.AudioMessages
            .Include(m => m.Owner)
            .Where(m => m.Category == category)
            .ToListAsync();
    }
}