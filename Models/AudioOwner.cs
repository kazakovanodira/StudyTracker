namespace StudyTracker.Models;

public class AudioOwner
{
    public Guid AudioOwnerId { get; set; }
    public string OwnerName { get; set; } = "";
    public ICollection<AudioMessage> AudioMessages { get; set; } = new List<AudioMessage>();
}