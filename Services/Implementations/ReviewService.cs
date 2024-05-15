using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Services.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories;
using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.Models;
namespace Rodriguez_Camani_Feresin_Backend.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        //private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public void CreateReview(int idTurno, ReviewDTO reviewdto)
        {
            throw new NotImplementedException();
            //if (reviewdto.UsernameInReview != null)
            //{
            //    var review = _mapper.Map<Review>(reviewdto);

            //    _reviewRepository.CreateReview(review);
            //}

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
            throw new NotImplementedException();
            //return _reviewRepository.GetReviews();
        }

        public void DeleteReview(int reviewid)
        {
            throw new NotImplementedException();
            //_reviewRepository.DeleteReview(reviewId);
        }

    }
}