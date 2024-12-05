using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class Book
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = null!;

        public DateTime PublishDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NoOfPages { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
    }
}
