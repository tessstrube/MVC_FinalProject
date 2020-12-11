using MotionMania2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionMania2.Models
{
    public class MovieReviewDetail
    {
        [Display(Name = "ID")]
        public int MovieReviewId { get; set; }

        [Display(Name = "Title")]
        public string MovieTitle { get; set; }

        [Display(Name = "Release Year")]
        public string MovieReleaseYear { get; set; }

        public string Director { get; set; }

        [Display(Name = "Genre")]
        public MovieGenre MovieGenre { get; set; }

        [Display(Name = "Mania")]
        public string MovieMania { get; set; }

        [Display(Name = "Rating")]
        public int MovieRating { get; set; }

    }
}