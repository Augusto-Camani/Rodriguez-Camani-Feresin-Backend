using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend.Services.Interfaces
{
    public interface IClientService
    {
        //void UpdateReview(int id, ReviewDTO reviewdto);
        //void CreateReview(ReviewDTO reviewpostdto, int idTurno);
        void CreateClient(ClientDTO clientdto);
        public void UpdateClient(int id, ClientDTO clientdto);
    }
}
