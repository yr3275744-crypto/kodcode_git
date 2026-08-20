using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitsApi.Data;
using UnitsApi.Models.Readings;

namespace UnitsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        public AppDbContext DbContext { get; set; }
        public UnitsController(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<uav_models_reading>>> GetModelsAsync()
        {
            var result = await DbContext.Uavs.Select(u => new uav_models_reading
            {
                model_id = u.model_id,
                max_range_km = u.max_range_km,
                endurance_minutes = u.endurance_minutes,
                model_class = u.model_class,
                model_name = u.model_name,
                sensor_payload = u.sensor_payload
            })
                .ToListAsync();
            return Ok(result);
        }
    }
}
