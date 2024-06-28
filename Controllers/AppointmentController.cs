using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend;

[Route("[Controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("get-barber-appointments")]
    [Authorize(Policy = "BothPolicy")]
    public IActionResult GetAvailableBarberAppointmentsByDate([FromQuery] int id, [FromBody] DateTime datetime)
    {
        try
        {
            var appointments = _appointmentService.GetAvailableBarberAppointmentsByDate(id, datetime);
            if (appointments == null || !appointments.Any())
            {
                return NotFound("No se encontraron turnos disponibles del barbero en la fecha especificada.");
            }
            return Ok(appointments);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("create-appointment")]
    [Authorize(Policy = "ClientPolicy")]
    public IActionResult CreateAppointment([FromBody] AppointmentDTO appointmentDTO)
    {
        try
        {
            _appointmentService.CreateAppointment(appointmentDTO);
            return Created();

        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get-appointments-by-barberId")]
    [Authorize(Policy = "BothPolicy")]
    public IActionResult GetAppointmentsByBarberId([FromQuery] int barberId)
    {
        try
        {
            var appointments = _appointmentService.GetAppointmentsByBarberId(barberId);
            if (appointments == null || !appointments.Any())
            {
                return NotFound("No se encontraron turnos del barbero.");
            }
            return Ok(appointments);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get-appointment-by-id")]
    [Authorize(Policy = "BothPolicy")]
    public IActionResult GetAppointmentById([FromQuery] int appointmentId)
    {
        try
        {
            var appointment = _appointmentService.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return NotFound("No se encontró ningun turno.");
            }
            return Ok(appointment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("get-appointments-by-barber-and-date")]
    [Authorize(Policy = "BothPolicy")]
    public IActionResult GetAppointmentsByBarberAndDate([FromQuery] int barberId, DateTime date)
    {
        try
        {
            var appointments = _appointmentService.GetAppointmentsByBarberAndDate(barberId, date);
            if (appointments == null || !appointments.Any())
            {
                return NotFound("No se encontraron turnos del barbero en la fecha especificada.");
            }
            return Ok(appointments);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete-appointment/{appointmentId}")]
    [Authorize(Policy = "BothPolicy")]
    public IActionResult DeleteAppointment([FromRoute] int appointmentId)
    {
        try
        {
            var appointment = _appointmentService.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return NotFound("No se encontro el turno.");
            }
            _appointmentService.DeleteAppointment(appointmentId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
