using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetReviews();
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
    }
}