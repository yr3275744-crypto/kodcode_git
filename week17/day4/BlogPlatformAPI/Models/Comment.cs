using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogPlatformAPI.Models;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    [Required]
    public string? CommenterName { get; set; }
    public string? Text { get; set; }

    [Required]
    public DateTime? CreatedAt { get; set; }
}
