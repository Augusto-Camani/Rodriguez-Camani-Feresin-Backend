using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;

        }

        // ADMIN? BARBER?
        [HttpGet("GetReviews")]
        public IActionResult GetReviews()
        {
            return Ok(_reviewService.GetReviews());
        }

        //ADMIN??
        [HttpGet("DeleteReview/{reviewid}")]
        public IActionResult DeleteReview(int reviewid)
        {
            _reviewService.DeleteReview(reviewid);
            return Ok("Review Deleted");
        }
    }
}
