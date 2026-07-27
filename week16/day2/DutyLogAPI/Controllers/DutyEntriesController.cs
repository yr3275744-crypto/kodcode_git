using DutyLogAPI.models;
using Microsoft.AspNetCore.Mvc;

namespace DutyLogAPI.Controllers;

[ApiController]
[Route("DutyLogAPI/[controller]")]
public class DutyEntriesController : ControllerBase
{
    public static readonly List<DutyEntry> _dutyEntries = new()
    {
        new DutyEntry
        {
            Id = 1,
            Name = "John Smith",
            StationName = "North Gate",
            StationNumber = 101,
            ShiftStart = new DateTime(2026, 7, 27, 6, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 27, 14, 0, 0),
            Remarks = "Morning shift"
        },
        new DutyEntry
        {
            Id = 2,
            Name = "Sarah Johnson",
            StationName = "Control Room",
            StationNumber = 205,
            ShiftStart = new DateTime(2026, 7, 27, 14, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 27, 22, 0, 0),
            Remarks = "Equipment check completed"
        },
        new DutyEntry
        {
            Id = 3,
            Name = "David Brown",
            StationName = "Warehouse",
            StationNumber = 310,
            ShiftStart = new DateTime(2026, 7, 28, 8, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 28, 16, 0, 0),
            Remarks = "Routine patrol"
        },
        new DutyEntry
        {
            Id = 4,
            Name = "Emily Davis",
            StationName = "Main Entrance",
            StationNumber = 15,
            ShiftStart = new DateTime(2026, 7, 28, 16, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 29, 0, 0, 0),
            Remarks = "Visitor assistance"
        },
        new DutyEntry
        {
            Id = 5,
            Name = "Michael Wilson",
            StationName = "Parking Lot",
            StationNumber = 78,
            ShiftStart = new DateTime(2026, 7, 29, 0, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 29, 8, 0, 0),
            Remarks = "Night shift"
        },
        new DutyEntry
        {
            Id = 6,
            Name = "Olivia Martinez",
            StationName = "East Gate",
            StationNumber = 420,
            ShiftStart = new DateTime(2026, 7, 29, 6, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 29, 14, 0, 0),
            Remarks = "No incidents"
        },
        new DutyEntry
        {
            Id = 7,
            Name = "James Taylor",
            StationName = "Security Office",
            StationNumber = 512,
            ShiftStart = new DateTime(2026, 7, 30, 8, 30, 0),
            ShiftEnd = new DateTime(2026, 7, 30, 17, 0, 0),
            Remarks = "Prepared daily report"
        },
        new DutyEntry
        {
            Id = 8,
            Name = "Sophia Anderson",
            StationName = "South Gate",
            StationNumber = 88,
            ShiftStart = new DateTime(2026, 7, 30, 14, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 30, 22, 0, 0),
            Remarks = "Gate maintenance"
        },
        new DutyEntry
        {
            Id = 9,
            Name = "William Thomas",
            StationName = "Operations Center",
            StationNumber = 640,
            ShiftStart = new DateTime(2026, 7, 31, 7, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 31, 15, 0, 0),
            Remarks = "System monitoring"
        },
        new DutyEntry
        {
            Id = 10,
            Name = "Emma White",
            StationName = "West Gate",
            StationNumber = 999,
            ShiftStart = new DateTime(2026, 7, 31, 15, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 31, 23, 0, 0),
            Remarks = "Shift completed"
        }
    };
    private int _nextId = 11;

    [HttpGet]
    public ActionResult<IEnumerable<DutyEntry>> GetAll()
    {
        return Ok(_dutyEntries);
    }

    [HttpGet("{id}")]
    public ActionResult<DutyEntry> GetById(int id)
    {
        DutyEntry? dutyEntry = _dutyEntries
            .FirstOrDefault(d => d.Id == id);
        if (dutyEntry == null)
        {
            return NotFound();
        }
        return Ok(dutyEntry);
    }

    [HttpPost]
    public ActionResult<DutyEntry> AddDutyEntry(DutyEntry dutyEntry)
    {
        dutyEntry.Id = _nextId;
        _dutyEntries.Add(dutyEntry);
        return CreatedAtAction(nameof(GetById), new { id = dutyEntry.Id }, dutyEntry);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDutyEntry(int id, DutyEntry dutyEntry)
    {
        DutyEntry? exsistDutyEntry = _dutyEntries
            .FirstOrDefault(d => d.Id == id);
        if (exsistDutyEntry == null)
        {
            return NotFound();
        }
        exsistDutyEntry.Name = dutyEntry.Name;
        exsistDutyEntry.StationName = dutyEntry.StationName;
        exsistDutyEntry.StationNumber = dutyEntry.StationNumber;
        exsistDutyEntry.ShiftStart = dutyEntry.ShiftStart;
        exsistDutyEntry.ShiftEnd = dutyEntry.ShiftEnd;
        exsistDutyEntry.Remarks = dutyEntry.Remarks;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById(int id)
    {
        DutyEntry? exsistDutyEntry = _dutyEntries
           .FirstOrDefault(d => d.Id == id);
        if (exsistDutyEntry == null)
        {
            return NotFound();
        }
        _dutyEntries.Remove(exsistDutyEntry);
        return NoContent();
    }
}
