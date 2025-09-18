using Microsoft.EntityFrameworkCore;
using StudyTracker.Context;
using StudyTracker.Interfaces;
using StudyTracker.Models.EFModels;

namespace StudyTracker.Repositories;

public class StudyLogRepository : IStudyLogRepository
{
    private readonly StudyContext _context;
    public StudyLogRepository(StudyContext context) => _context = context;

    public async Task<StudyLog> AddAsync(StudyLog log)
    {
        _context.StudyLogs.Add(log);
        await _context.SaveChangesAsync();
        return log;
    }

    public async Task<ICollection<StudyLog>> GetAllAsync()
    {
        return await _context.StudyLogs.ToListAsync();
    }

    public async Task<StudyLog> GetById(Guid id)
    {
        return await _context.StudyLogs.FindAsync(id);
    }
}