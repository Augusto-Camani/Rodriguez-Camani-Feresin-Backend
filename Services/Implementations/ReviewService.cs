using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Models;
using AutoMapper;
using Rodriguez_Camani_Feresin_Backend.Controllers;

namespace Rodriguez_Camani_Feresin_Backend.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public void CreateReview(int idTurno, ReviewDTO reviewDTO)
        {
            var review = _mapper.Map<Review>(reviewDTO);
            review.AppointmentId = idTurno; 
            _reviewRepository.CreateReview(review);
        }

        public void DeleteReview(int reviewId)
        {
          _reviewRepository.DeleteReview(reviewId);
        }

        public Review GetReviewById(int reviewId)
        {
            return _reviewRepository.GetReviewById(reviewId);
        }

        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetReviews();
        }

        public IEnumerable<Review> GetReviewsByUserId(int userId)
        {
           return _reviewRepository.GetReviewsByUserId(userId);
        }

        public void UpdateReview(int reviweId, ReviewDTO reviewDTO)
        {

               var existingReview = _reviewRepository.GetReviewById(reviweId);
               if (existingReview == null)
               {
                   throw new Exception("Review NO encontrada");
               }

               existingReview.Description = reviewDTO.ClientComment;
               existingReview.Rating = reviewDTO.ClientRating;
               _reviewRepository.UpdateReview(existingReview);
            }
        }
}
