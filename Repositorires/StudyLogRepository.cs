using StudyTracker.Interfaces;
using StudyTracker.Models;

namespace StudyTracker.Repositorires;

public class StudyLogRepository: IStudyLogRepository
{
    public Task<StudyLog> AddAsync(StudyLog log)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<StudyLog>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudyLog> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}