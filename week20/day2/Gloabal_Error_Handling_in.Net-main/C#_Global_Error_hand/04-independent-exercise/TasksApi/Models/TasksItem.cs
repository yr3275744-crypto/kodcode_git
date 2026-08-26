using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TasksApi.Models
{
    public enum StatusEnum
    {
        pending,
        completed
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusEnum status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
