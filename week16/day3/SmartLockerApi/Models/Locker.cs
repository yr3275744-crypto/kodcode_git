using System.ComponentModel.DataAnnotations;
namespace SmartLockerApi.Models;

public class Locker
{
    public int Id { get; set; }

    [Required]
    [Range(1, 500,
        ErrorMessage = "Locker number must be between 1 and 500")]
    public int LockerNumber { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "Available";

    [StringLength(100)]
    public string? AssignedTo { get; set; }

    [StringLength(200)]
    public string? EquipmentType { get; set; }
    public DateTime? AssignedAt { get; set; }
}
