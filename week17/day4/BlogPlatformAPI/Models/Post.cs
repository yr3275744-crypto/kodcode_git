using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.Models;

public class Post
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Body { get; set; }
    public DateTime? PublishedDate { get; set; }
    public bool IsPublished { get; set; } = false;
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
