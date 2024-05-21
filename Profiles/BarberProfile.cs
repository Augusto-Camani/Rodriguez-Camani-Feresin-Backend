using AutoMapper;

namespace Rodriguez_Camani_Feresin_Backend;

public class BarberProfile : Profile
{
    public BarberProfile()
    {
        CreateMap<Barber, BarberDTO>();
        CreateMap<BarberDTO, Barber>();
    }

}
