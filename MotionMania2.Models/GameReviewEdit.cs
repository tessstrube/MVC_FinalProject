using MotionMania2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionMania2.Models
{
    public class GameReviewEdit
    {

        public int GameReviewId { get; set; }

        [Display(Name = "Title")]
        public string GameTitle { get; set; }

        [Display(Name = "Delevoper")]
        public string GameDeveloper { get; set; }

        public Platform Platform { get; set; }

        [Display(Name = "Genre")]
        public GameGenre GameGenre { get; set; }

        [Range(1958, 2018, ErrorMessage = "Please enter a valid year")]
        [Display(Name = "Release Year")]
        public int GameReleaseYear { get; set; }

        [Display(Name = "Mania")]
        public string GameMania { get; set; }

        [Range(1, 10, ErrorMessage = "Please enter a rating on a scale of 1-10")]
        [Display(Name = "Rating")]
        public int GameRating { get; set; }
    }
}