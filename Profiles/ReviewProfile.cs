using AutoMapper;
using Rodriguez_Camani_Feresin_Backend.DTO;

namespace Rodriguez_Camani_Feresin_Backend.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();
        }
    }
}