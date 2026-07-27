using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace DutyLogAPI.models;

public class DutyEntry
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string StationName { get; set; } = "";

    [Range(1, 1000 , ErrorMessage = "Invalid Station number, it must be between 1 and 1000")]
    public double StationNumber { get; set; }
    public DateTime ShiftStart { get; set; }
    public DateTime ShiftEnd { get; set; }

    [StringLength(50,
        ErrorMessage = "Invalid Remarks, it must be smaller then 50 nots")]
    public string Remarks { get; set; } = "";
}