using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionMania2.Data
{
    public enum Platform
    {
        Android = 1,
        DS,
        GameBoy,
        [Display(Name = "iOS")]
        IOS,
        PC,
        PlayStation,
        PS2,
        PS3,
        PS4,
        Switch,
        Xbox,
        [Display(Name = "Xbox 360")]
        Xbox360,
        [Display(Name = "Xbox One")]
        XboxOne,
        Wii,
        [Display(Name = "Wii U")]
        WiiU,
        Other
    }

    public enum GameGenre
    {
        Adventure = 1,
        Combat,
        Educational,
        [Display(Name = "First Person Shooter (FPS)")]
        FPS,
        MMO,
        Puzzle,
        RPG,
        Sport,
        [Display(Name = "Stealth Shooter")]
        StealthShooter,
        Strategy,
        [Display(Name = "Virtual Reality")]
        VirtualReality
    }

    public class GameReview
    {
        [Key]
        public int GameReviewId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string GameTitle { get; set; }

        [Required]
        public string GameDeveloper { get; set; }

        [Required]
        public Platform Platform { get; set; }

        [Required]
        public GameGenre GameGenre { get; set; }

        [Required]
        [Range(1958, 2018, ErrorMessage = "Please enter a valid year")]
        public int GameReleaseYear { get; set; }

        [Required]
        public string GameMania { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Please enter a rating on a scale of 1-10")]
        public int GameRating { get; set; }


    }
}