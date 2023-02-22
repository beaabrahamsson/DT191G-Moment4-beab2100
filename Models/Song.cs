using System.ComponentModel.DataAnnotations;

namespace DT191G_Moment4_beab2100.Models {
    public class Song {
        //properties
        public int Id { get; set; }
        [Required(ErrorMessage = "Ange en artist")]
        public string? Artist { get; set; }
        [Required(ErrorMessage = "Ange en titel")]
        public string? Titel { get; set; }
        [Required(ErrorMessage = "Ange en längd")]
        public int Lenght { get; set; }
        [Required(ErrorMessage = "Ange en kategori")]
        public string? Category { get; set; }
        public int? RatingId { get; set; }
        public Rating? RatingNumber { get; set; }
    }

    public class Rating {
        //properties
        public int RatingId { get; set; }
        [Required(ErrorMessage = "Ange en siffra mellan 1 och 5")]
        [Range(1, 5)]
        public int? Number { get; set; }

    }
}