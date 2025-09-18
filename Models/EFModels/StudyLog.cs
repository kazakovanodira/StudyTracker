namespace StudyTracker.Models.EFModels;

public class StudyLog
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public double Hours { get; set; }
}