﻿namespace Rodriguez_Camani_Feresin_Backend.DTO
{
    public class ReviewDTO
    {
        public int AppointmentId { get; set; }
        public string ClientUsername { get; set; }
        public decimal ClientRating { get; set; }
        public string ClientComment { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}