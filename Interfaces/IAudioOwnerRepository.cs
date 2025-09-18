using StudyTracker.Models.EFModels;

namespace StudyTracker.Interfaces;

public interface IAudioOwnerRepository
{
    Task<AudioOwner> AddAsync(AudioOwner owner);
    Task<AudioOwner?> GetByOwnerName(string name);
    Task<ICollection<AudioOwner>> GetAllAsync();
}