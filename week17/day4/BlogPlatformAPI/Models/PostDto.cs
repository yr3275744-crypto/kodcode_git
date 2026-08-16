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

    public AuthorDto Author { get; set; }
    public ICollection<CommentDto>? Comments { get; set; }
    public PostDto(int id, int authorId, string? title, string? body, AuthorDto author, ICollection<CommentDto>? comments)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        Body = body;
        Author = author;
        Comments = comments;
    }
}