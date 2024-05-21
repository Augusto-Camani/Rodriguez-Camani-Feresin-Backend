using AutoMapper;
using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDTO>();
        CreateMap<ClientDTO, Client>();
    }
}
