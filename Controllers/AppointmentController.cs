using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetAvailableBarberAppointmentsByDate()
    {
        return Ok();
    }

    [HttpPost("create-appointment")]
    public IActionResult CreateAppointment()
    {
        return Ok();
    }

    [HttpDelete("delete-appointment/{appointmentId}")]
    public IActionResult DeleteAppointment([FromRoute] int appointmentId)
    {
        return Ok();
    }
}
