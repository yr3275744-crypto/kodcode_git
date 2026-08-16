using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.Models;

public class Author
{
    public int Id { get; set; }

    [Required]
    public string? FullName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public DateTime? JoinedDate { get; set; }
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}