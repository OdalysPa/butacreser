using System.ComponentModel.DataAnnotations;

namespace CinemaBookingSystem.Models
{
    public enum MovieGenreEnum
    {
        ACTION,
        ADVENTURE,
        COMEDY,
        DRAMA,
        FANTASY,
        HORROR,
        MUSICALS,
        MYSTERY,
        ROMANCE,
        SCI_FI,
        SPORTS,
        THRILLER,
        WESTERN
    }

    public class MovieEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public MovieGenreEnum Genre { get; set; }

        [Required]
        public short AllowedAge { get; set; }

        [Required]
        public short DurationMinutes { get; set; }
    }
}
