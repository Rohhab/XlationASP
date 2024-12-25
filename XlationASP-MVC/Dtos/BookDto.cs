using System.ComponentModel.DataAnnotations;

namespace XlationASP.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please make sure to enter the title")]
        [MaxLength(255)]
        public string Title { get; set; } = null!;

        [Display(Name = "Publish Date")]
        [Required(ErrorMessage = "Please make sure to enter publish date")]
        public DateTime PublishDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "No. of Pages")]
        [Required(ErrorMessage = "Please make sure to enter no. of pages")]
        [Range(5, double.MaxValue, ErrorMessage = "The book shall have at least 5 page")]
        public int NoOfPages { get; set; }

        public GenreDto Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please make sure to select the genre")]
        public byte GenreId { get; set; }
    }
}
