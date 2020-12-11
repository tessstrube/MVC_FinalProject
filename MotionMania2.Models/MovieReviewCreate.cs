using MotionMania2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionMania2.Models
{
    public class MovieReviewCreate
    {
        [Required]
        [Display(Name = "Title")]
        public string MovieTitle { get; set; }

        [Required]
        [Display(Name = "Release Year")]
        public string MovieReleaseYear { get; set; }

        [Required]
        [Display(Name = "Director")]
        public string Director { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public MovieGenre MovieGenre { get; set; }

        [Required]
        [Display(Name = "Mania")]
        public string MovieMania { get; set; }

        [Required]
        [Display(Name = "Rating")]
        public int MovieRating { get; set; }

        public override string ToString() => MovieTitle;
    }
}
