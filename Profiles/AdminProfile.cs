using AutoMapper;

namespace Rodriguez_Camani_Feresin_Backend;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<Admin, AdminDTO>();
        CreateMap<AdminDTO, Admin>();
    }
}
