using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlogPlatformAPI.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? CommenterName { get; set; }
        public string? Text { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
