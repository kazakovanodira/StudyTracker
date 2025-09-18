using StudyTracker.Models.EFModels;

namespace StudyTracker.Interfaces;

public interface IAudioMessageRepository
{
    Task<AudioMessage> AddAsync(AudioMessage audioMsg);
    Task<AudioMessage?> GetByMessageFilePath(string filePath);
    Task<ICollection<AudioMessage>> GetByCategory(Category category);
    Task<AudioMessage?> UpdateFilePathAsync(int audioMessageId, string newFilePath);

}