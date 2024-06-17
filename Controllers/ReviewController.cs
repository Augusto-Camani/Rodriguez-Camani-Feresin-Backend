using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;

        }

        // ADMIN? BARBER?
        [HttpGet("get-reviews")]
        public IActionResult GetReviews()
        {
            return Ok(_reviewService.GetReviews());
        }

        [HttpGet("get-reviews-by-userId/{userId}")]
        public IActionResult GetReviewsByUserId([FromRoute] int userId)
        {
            var reviews = _reviewService.GetReviewsByUserId(userId);

            if (!reviews.Any())
            {
                return BadRequest("El cliente no tiene ninguna reseña creada.");
            }

            return Ok(reviews);
        }

        //ADMIN??
        [HttpGet("delete-review/{reviewid}")]
        public IActionResult DeleteReview(int reviewid)
        {
            _reviewService.DeleteReview(reviewid);
            return Ok("Review Deleted");
        }

        [HttpPost("add-review")]
        public IActionResult CreateReview([FromQuery] int idTurno, [FromBody] ReviewDTO reviewdto)
        {
            _reviewService.CreateReview(idTurno, reviewdto);
            return Created();
        }


    }
}