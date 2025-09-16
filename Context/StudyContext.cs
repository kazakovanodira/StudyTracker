using Microsoft.EntityFrameworkCore;
using StudyTracker.Models;

namespace StudyTracker.Context;

public class StudyContext : DbContext
{
    public StudyContext(DbContextOptions<StudyContext> options) : base(options) { }

    public DbSet<StudyLog> StudyLogs { get; set; }
    public DbSet<AudioOwner> AudioOwners { get; set; }
    public DbSet<AudioMessage> AudioMessages { get; set; }
}