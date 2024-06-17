using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Models;
using AutoMapper;

namespace Rodriguez_Camani_Feresin_Backend.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public void CreateReview(int idTurno, ReviewDTO reviewdto)
        {
            var review = _mapper.Map<Review>(reviewdto);
            review.AppointmentId = idTurno; 
            _reviewRepository.CreateReview(review);
        }

        public void UpdateReview(int id, ReviewDTO reviewdto)
        {
            throw new NotImplementedException();

            // VER COMO HACER, SI OBTIENE LA REVIEW POR ID O POR USERNAME O POR QUÉ MEDIO
            //    var existsReview = _reviewRepository.GetReviewById(reviewid);
            //    if (existsReview == null)
            //    {
            //        throw new Exception("Review NO encontrada");
            //    }
            //    // Mapea las propiedades de manera individual, del DTO a la entidad existente.
            //    existsReview.GameId = reviewdto.GameId;
            //    existsReview.UserNameInReview = reviewdto.UsernameInReview;
            //    existsReview.UserCommentInReview = reviewdto.UserCommentInReview;
            //    existsReview.UserRatingInReview = reviewdto.UserRatingInReview;
            //    existsReview.CreationDate = reviewdto.CreationDate;
            //    // Actualiza la entidad en el repositorio
            //    _reviewRepository.UpdateReview(existsReview);
            //}
        }

        public IEnumerable<Review> GetReviews()
        {
            return _reviewRepository.GetReviews();
        }

        public void DeleteReview(int reviewId)
        {
            _reviewRepository.DeleteReview(reviewId);
        }

        public List<ReviewDTO> GetReviewsByUserId(int userId)
        {
            return _reviewRepository.GetReviewsByUserId(userId).ToList();
        }
    }
}