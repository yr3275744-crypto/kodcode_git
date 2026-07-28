using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VehicleFleetRegistryAPI.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum VehicleStatus
{
    Available,
    InUse,
    Maintenance,
    Decommissioned
}

public class Vehicle
{
    public int Id { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "Registration number must be 5 -15")]
    public string RegistrationNumber { get; set; } = "";

    [Required]
    [StringLength(50, ErrorMessage = "Vehicle type must be less then 50 nots")]
    public string VehicleType { get; set; } = "";

    [Required]
    public VehicleStatus? Status { get; set; } = null;

    [StringLength(50, ErrorMessage = "Assigned driver must be less then 50 nots")]
    public string? AssignedDriver { get; set; }

    [StringLength(200, ErrorMessage = "Current location must be less then 200 nots")]
    public string? CurrentLocation { get; set; }

    [Required]
    [Range(0, 500000, ErrorMessage = "Mileage must be 0 - 500000 km")]
    public double Mileage { get; set; }
}
