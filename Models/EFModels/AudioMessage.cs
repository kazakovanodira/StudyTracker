namespace StudyTracker.Models.EFModels;

public class AudioMessage
{
    public Guid AudioMessageId { get; set; }
    public string FilePath { get; set; } = "";
    public Category Category { get; set; }

    public Guid OwnerId { get; set; }
    public AudioOwner Owner { get; set; } 
}

public enum Category
{
    Little, 
    Good, 
    Exceptional
}