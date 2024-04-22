using Microsoft.AspNetCore.Mvc;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Implementations;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IReviewService _reviewService;
        private readonly IAppointmentService _appointmentService;
        public ClientController(IClientService clientService, IReviewService reviewService, IAppointmentService appointmentService)
        {
            _clientService = clientService;
            _reviewService = reviewService;
            _appointmentService = appointmentService;
        }
        [HttpPost("CreateClient")]
        //[Authorize("All")]
        public IActionResult CreateClient([FromBody] ClientDTO clientDto)
        {

            _clientService.CreateClient(clientDto);
            return StatusCode(201);
        }
        [HttpPatch("UpdateClient")]
        public IActionResult UpdateClient(int id, ClientDTO clientdto)
        {
            //if (_clientService.GetClientById(id) == null)
            //{
            //    return BadRequest("El cliente no existe");
            //}
            _clientService.UpdateClient(id, clientdto);
            return Ok("Cliente Actualizado");
        }

        [HttpPost("CreateReview")]
        public IActionResult CreateReview([FromBody] int idturno, ReviewDTO reviewdto)
        {
            _reviewService.CreateReview(idturno, reviewdto);
            return Ok();
        }
        [HttpPatch("UpdateReview/{idturno}")]

        // VER SI ENCUENTRA O NO LA REVIEW
        public IActionResult UpdateReview(int idturno, ReviewDTO reviewdto)
        {
            _reviewService.UpdateReview(idturno, reviewdto);
            return Ok("Review Updated");
        }

        [HttpPost("CreateAppointment")]
        public IActionResult CreateAppointment([FromBody] AppointmentDTO appointmentdto)
        {
            _appointmentService.CreateAppointment(appointmentdto);
            return Ok();
        }

    }
}
