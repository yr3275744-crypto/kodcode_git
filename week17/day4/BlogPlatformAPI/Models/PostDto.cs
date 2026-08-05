using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.Models;

public class PostDto
{
    public int Id { get; set; }
    public int AuthorId { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Body { get; set; }
}