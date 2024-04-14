
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces
{
    public interface IClientRepository
    {
        void CreateClient(User user);
        void UpdateUser(User user);
        //void CreateReview(Review newreview);
        //void UpdateReview(Review updatereview);
    }
}
