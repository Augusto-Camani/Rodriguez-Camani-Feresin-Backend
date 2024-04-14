using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;

namespace Rodriguez_Camani_Feresin_Backend.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        //private readonly IMapper _mapper;
        private readonly RodriguezCamaniFeresinContext _context;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;

        }
        public void CreateClient(ClientDTO clientdto)
        {
            //if (!ValidatePassword(clientdto.Password))
            //{
            //    throw new Exception("The password does not meet the requirements. it must have at least one number and one special character");
            //}
            //var newUser = _mapper.Map<Client>(userDto);
            //_ClientRepository.CreateClient(newUser);
        }
        public void UpdateClient(int id, ClientDTO user)
        {
            //var existsUser = _clientRepository.GetUserById(id);
            //if (existsUser == null)
            //{
            //    throw new Exception("Usuario NO encontrado");
            //}
            //if (!ValidatePassword(user.Password))
            //{
            //    throw new Exception("The password does not meet the requirements.");
            //}
            //existsUser.UserName = user.UserName;
            //existsUser.Email = user.Email;

            //_userRepository.UpdateUser(existsUser);
            //_userRepository.SaveChanges();
        }
        //public void UpdateReview(int id, ReviewDto reviewdto)
        //{
        //    throw new NotImplementedException();
        //}
        //public void CreateReview(ReviewDTO, int idTurno)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
