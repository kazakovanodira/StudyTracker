namespace StudyTracker.Models;

public class AudioOwner
{
    public Guid OwnerId { get; set; }
    public string OwnerName { get; set; } = "";
    public ICollection<AudioMessage> AudioMessages { get; set; }
}