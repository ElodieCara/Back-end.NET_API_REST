﻿namespace Dot.Net.WebApi.Models
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public string MoodysRating { get; set; }
        public string SandPRating { get; set; }
        public string FitchRating { get; set; }
        public int? OrderNumber { get; set; }
    }
}