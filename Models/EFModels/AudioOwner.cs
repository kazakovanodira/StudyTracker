using System.ComponentModel.DataAnnotations;

namespace StudyTracker.Models.EFModels;

public class AudioOwner
{
    public int AudioOwnerId { get; set; }
    [Required]
    public string OwnerName { get; set; } = "";
    public ICollection<AudioMessage> AudioMessages { get; set; } = new List<AudioMessage>();
}