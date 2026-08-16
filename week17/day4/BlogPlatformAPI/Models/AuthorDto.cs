using System.ComponentModel.DataAnnotations;

namespace BlogPlatformAPI.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime? JoinedDate { get; set; }
    }
}
