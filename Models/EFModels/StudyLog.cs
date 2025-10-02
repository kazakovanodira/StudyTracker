namespace StudyTracker.Models.EFModels;

public class StudyLog
{
    public int StudyLogId { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Hours { get; set; }
}