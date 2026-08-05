using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChannelAPI.Models;

[Index(nameof(Name), IsUnique = true)]
public class Channel
{
    //public int Id { get; set; }
    [Key]
    public string Name { get; set; } = string.Empty;
    public string Zone { get; set; } = string.Empty;
    public ICollection<Message> Messages { get; set; } = new List<Message>();

}
