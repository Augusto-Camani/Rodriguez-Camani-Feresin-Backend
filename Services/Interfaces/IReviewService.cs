using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Services.Interfaces
{
    public interface IReviewService
    {
        public IEnumerable<Review> GetReviews();
        public Review GetReviewById(int reviewId);
        public IEnumerable<Review> GetReviewsByUserId(int userId);
        void DeleteReview(int reviewId);
        void UpdateReview(int idTurno, ReviewDTO reviewDTO);
        void CreateReview(int idTurno, ReviewDTO reviewDTO);
        

    }
}