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

        [HttpGet("get-reviews")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult GetReviews()
        {
            return Ok(_reviewService.GetReviews());
        }

        [HttpGet("get-reviews-by-userId/{userId}")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult GetReviewsByUserId([FromRoute] int userId)
        {
            var reviews = _reviewService.GetReviewsByUserId(userId);

            if (!reviews.Any())
            {
                return BadRequest("El cliente no tiene ninguna reseña creada.");
            }

            return Ok(reviews);
        }

        [HttpGet("get-review-by-id/{reviewId}")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult GetReviewById([FromRoute] int reviewId)
        {
            return Ok(_reviewService.GetReviewById(reviewId));
        }

        [HttpGet("delete-review/{reviewId}")]
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult DeleteReview(int reviewId)
        {
            _reviewService.DeleteReview(reviewId);
            return Ok("Review Deleted");
        }

        [HttpPost("add-review")]
        [Authorize(Policy = "ClientPolicy")]
        public IActionResult CreateReview([FromQuery] int idTurno, [FromBody] ReviewDTO reviewDTO)
        {
            _reviewService.CreateReview(idTurno, reviewDTO);
            return Created();
        }
    }
}