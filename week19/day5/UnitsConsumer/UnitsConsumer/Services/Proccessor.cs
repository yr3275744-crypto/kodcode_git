//אולי צריך למשוך אליי את האב באמצעות שאילתה ל db context

using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnitsConsumer.Data;
using UnitsConsumer.Models;
using UnitsConsumer.Models.Readings;

namespace UnitsConsumer.Services
{
    public class Proccessor
    {
        private readonly AppDbContext _dbContext;
        public Proccessor(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ProccessModel(string message)
        {
            //try
            //{
            uav_models_reading? reading = JsonSerializer.Deserialize<uav_models_reading>(message);
            if (reading == null)
            {
                return false;
            }
            UavModels model = new UavModels
            {
                model_id = reading.model_id,
                model_name = reading.model_name,
                model_class = reading.model_class,
                max_range_km = reading.max_range_km,
                endurance_minutes = reading.endurance_minutes,
                sensor_payload = reading.sensor_payload
            };
            _dbContext.Uavs.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
            //}
            //catch ()
        }
        public async Task<bool> ProccessHostileUnit(string message)
        {
            try
            {

                hostile_units_reading? reading = JsonSerializer.Deserialize<hostile_units_reading>(message);
                if (reading == null)
                {
                    Console.WriteLine("null..");
                    return false;
                    
                }
                UavModels? modelFather = await _dbContext.Uavs
                    .Where(u => u.model_id == reading.model_id)
                    .FirstOrDefaultAsync();
                if (modelFather == null)
                {
                    Console.WriteLine($"{reading.model_id} doese not found");
                    return false;
                }
                HostileUnits hostile = new HostileUnits
                {
                    unit_id = reading.unit_id,
                    model_id = reading.model_id,
                    operator_name = reading.operator_name,
                    first_seen_date = reading.first_seen_date,
                    status = reading.status,
                    home_lat = reading.home_lat,
                    home_lon = reading.home_lon,
                    UavModel = modelFather
                };
                if (modelFather.max_range_km < 50)
                {
                    hostile.threat_band = "low";
                }
                else if (modelFather.max_range_km < 200)
                {
                    hostile.threat_band = "medium";
                }
                else
                {
                    hostile.threat_band = "high";
                }
                _dbContext.HostileUnits.Add(hostile);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"fail send hotil unit, because: {ex.Message}");
                return false;
            }
            
        }
        public async Task<bool> ProccessTrack(string message)
        {
            tracks_reading? reading = JsonSerializer.Deserialize<tracks_reading>(message);
            if (reading == null)
            {
                Console.WriteLine("null..");
                return false;
            }
            string sectorCode = "S" + 
                Convert.ToString((int)reading.latitude) + 
                Convert.ToString((int)reading.longitude);
            Tracks track = new Tracks
            {
                track_id = reading.track_id,
                unit_id = reading.unit_id,
                report_time = reading.report_time,
                latitude = reading.latitude,
                longitude = reading.longitude,
                altitude_m = reading.altitude_m,
                signal_strength = reading.signal_strength,
                sector_code = sectorCode
            };
            _dbContext.Tracks.Add(track);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
