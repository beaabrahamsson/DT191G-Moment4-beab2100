using System.ComponentModel.DataAnnotations;

namespace DT191G_Moment4_beab2100.Models {
    public class Rating {
        public int RatingId { get; set; }
        [Required(ErrorMessage = "Ange en siffra mellan 1 och 5")]
        [Range(1, 5)]
        public int? Number { get; set; }

        public ICollection<Song>? Song { get; set; } 
    }
}