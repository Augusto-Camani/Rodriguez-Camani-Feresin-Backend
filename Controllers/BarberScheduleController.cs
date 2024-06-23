using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Filters;

namespace Rodriguez_Camani_Feresin_Backend
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarberSchedulesController : ControllerBase
    {
        private readonly IBarberScheduleService _barberScheduleService;

        public BarberSchedulesController(IBarberScheduleService barberScheduleService)
        {
            _barberScheduleService = barberScheduleService;
        }

        [HttpPost("{barberId}/schedules")]
        [Authorize(Policy = "BarberPolicy")]
        [SwaggerRequestExample(typeof(BarberScheduleDTO), typeof(BarberScheduleDTOExample))]
        public IActionResult CreateSchedule(int barberId, [FromBody] BarberScheduleDTO barberScheduleDTO)
        {
            try
            {
                _barberScheduleService.CreateSchedule(barberId, barberScheduleDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{barberId}/schedules")]
        [Authorize(Policy = "BarberPolicy")]
        public IActionResult GetSchedule(int barberId)
        {
            try
            {
                var schedule = _barberScheduleService.GetBarberScheduleById(barberId);
                if (schedule == null)
                {
                    return NotFound("Schedule not found.");
                }
                var scheduleDTO = new BarberScheduleDTO
                {
                    BarberId = schedule.BarberId,
                    CurrentYear = schedule.CurrentYear,
                    AvailabilitySlots = schedule.AvailabilitySlots.Select(ba => new BarberAvailabilityDTO
                    {
                        DayOfTheWeek = ba.DayOfTheWeek,
                        StartTime = ba.StartTime,
                        EndTime = ba.EndTime,
                        IsAvailable = ba.IsAvailable
                    }).ToList()
                };
                return Ok(scheduleDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("schedules")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult GetAllSchedules()
        {
            var schedules = _barberScheduleService.GetAllBarberSchedules().Select(schedule => new BarberScheduleDTO
            {
                BarberId = schedule.BarberId,
                CurrentYear = schedule.CurrentYear,
                AvailabilitySlots = schedule.AvailabilitySlots.Select(ba => new BarberAvailabilityDTO
                {
                    DayOfTheWeek = ba.DayOfTheWeek,
                    StartTime = ba.StartTime,
                    EndTime = ba.EndTime,
                    IsAvailable = ba.IsAvailable
                }).ToList()
            });
            return Ok(schedules);
        }
        
        [HttpGet("{barberName}")]
        [Authorize(Policy = "ClientPolicy")]
        public IActionResult GetScheduleByBarberName(string barberName)
        {
            try
            {
                var barberSchedule = _barberScheduleService.GetBarberScheduleByBarberName(barberName);
                if (barberSchedule == null)
                {
                    return NotFound("Schedule not found for the specified barber.");
                }
                return Ok(barberSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{barberId}/schedules")]
        [Authorize(Policy = "BarberPolicy")]
        public IActionResult DeleteSchedule(int barberId)
        {
            try
            {
                _barberScheduleService.DeleteSchedule(barberId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}