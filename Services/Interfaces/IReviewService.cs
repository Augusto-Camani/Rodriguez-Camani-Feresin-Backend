﻿using Rodriguez_Camani_Feresin_Backend.DTO;
using Rodriguez_Camani_Feresin_Backend.Models;

namespace Rodriguez_Camani_Feresin_Backend.Services.Interfaces
{
    public interface IReviewService
    {
        public IEnumerable<Review> GetReviews();
        void DeleteReview(int reviewid);
        // VER SI RECIBE ID TURNO
        void UpdateReview(int idTurno, ReviewDTO reviewdto);
        void CreateReview(int idTurno, ReviewDTO reviewpostdto);
    }
}