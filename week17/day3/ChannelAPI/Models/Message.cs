using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChannelAPI.Models;

public class Message
{
    public int Id { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;

    [Timestamp]
    public DateTime Timestemp { get; set; }

    [ForeignKey("ChannelName")]
    public Channel Channel { get; set; } = null!;
}