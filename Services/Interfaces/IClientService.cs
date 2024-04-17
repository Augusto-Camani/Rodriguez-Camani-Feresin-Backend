using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend.Services.Interfaces
{
    public interface IClientService
    {
        void CreateClient(ClientDTO clientdto);
        public void UpdateClient(int id, ClientDTO clientdto);
    }
}
