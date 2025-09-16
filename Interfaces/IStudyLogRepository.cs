using StudyTracker.Models;

namespace StudyTracker.Interfaces;

public interface IStudyLogRepository
{
    Task<StudyLog> AddAsync(StudyLog log);
    Task<ICollection<StudyLog>> GetAllAsync();
    Task<StudyLog> GetById(Guid id);
}