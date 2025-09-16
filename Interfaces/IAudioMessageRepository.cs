using StudyTracker.Models;

namespace StudyTracker.Interfaces;

public interface IAudioMessageRepository
{
    Task<AudioMessage> AddAsync(AudioMessage audioMsg);
    Task<ICollection<AudioMessage>> GetByCategory(Category category);
}