﻿using Rodriguez_Camani_Feresin_Backend.Data.Repositories.Interfaces;
using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Data.Repositories.Implementations
{
    public class ReviewRepository : Repository, IReviewRepository
    {
        public ReviewRepository(RodriguezCamaniFeresinContext context) : base(context)
        {
        }

        public void CreateReview(Review review)
        {
            throw new NotImplementedException();
            //_context.Add(review);
            //_context.SaveChanges();
        }

        public IEnumerable<Review> GetReviews()
        {
            throw new NotImplementedException();
            //return _context.Review;
        }

        public void DeleteReview(int id)
        {
            throw new NotImplementedException();
            //var reviewToDelete = _context.Reviews.Find(reviewId);
            //if (reviewToDelete != null)
            //{
            //    _context.Reviews.Remove(reviewToDelete);
            //    _context.SaveChanges();
            //}
        }

        public void UpdateReview(Review review)
        {
            throw new NotImplementedException();
            //_context.Update(review);
            //_context.SaveChanges();
        }
    }
}