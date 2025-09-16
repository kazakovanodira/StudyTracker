using StudyTracker.Interfaces;
using StudyTracker.Models;

namespace StudyTracker.Repositorires;

public class AudioMessageRepository: IAudioMessageRepository
{
    public Task<AudioMessage> AddAsync(AudioMessage audioMsg)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<AudioMessage>> GetByCategory(Category category)
    {
        throw new NotImplementedException();
    }
}