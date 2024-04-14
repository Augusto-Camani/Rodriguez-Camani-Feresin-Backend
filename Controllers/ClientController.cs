using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend.Controllers
{
    //[Route("/")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        //private readonly IReviewService _reviewService;
        //private readonly IAppointmentService _appointmentService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
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

        //[HttpPost("CreateReview")]

        //public IActionResult CreateReview([FromBody] ReviewDTO reviewDto)
        //{

        //    _reviewService.CreateReview(reviewDto);
        //    return StatusCode(201);
        //}

        //public IActionResult UpdateReview(int id, ReviewDTO reviewdto)
        //{
        //    if (_reviewService.GetReviewById(id) == null)
        //    {
        //        return BadRequest("La reseña no existe");
        //    }
        //    _reviewService.UpdateReview(id, reviewdto);
        //    return Ok("Review Actualizada");
        //}
    }
}
