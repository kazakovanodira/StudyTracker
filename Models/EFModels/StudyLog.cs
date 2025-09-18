using System.Runtime.InteropServices.JavaScript;

namespace StudyTracker.Models.EFModels;

public class StudyLog
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Hours { get; set; }
}