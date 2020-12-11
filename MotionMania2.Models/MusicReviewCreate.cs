using MotionMania2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionMania2.Models
{
    public class MusicReviewCreate
    {
        [Required]
        public string Artist { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string MusicTitle { get; set; }

        [Required]
        [Display(Name = "Release Type")]
        public ReleaseType ReleaseType { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public MusicGenreType MusicGenreType { get; set; }

        [Required]
        [Display(Name = "Mania")]
        public string MusicMania { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(1, 10, ErrorMessage = "Please enter a number between 1 and 10")]
        public int MusicRating { get; set; }

        public override string ToString() => $" {Artist} {MusicTitle} ";



    }
}