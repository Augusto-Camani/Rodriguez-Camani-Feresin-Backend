using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetReviews();
        public Review GetReviewById(int reviewId);
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int reviewId);
        public IEnumerable<Review> GetReviewsByUserId(int userId);

    }
}