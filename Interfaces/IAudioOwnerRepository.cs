using StudyTracker.Models;

namespace StudyTracker.Interfaces;

public interface IAudioOwnerRepository
{
    Task<AudioOwner> AddAsync(AudioOwner owner);
    Task<ICollection<AudioOwner>> GetAllAsync();
}