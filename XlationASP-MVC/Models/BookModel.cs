using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = null!;

        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "No. of Pages")]
        public int NoOfPages { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
    }
}
