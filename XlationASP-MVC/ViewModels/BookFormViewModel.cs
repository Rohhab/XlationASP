using System.ComponentModel.DataAnnotations;
using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; } = null!;

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please make sure to enter the title")]
        [MaxLength(255)]
        public string? Title { get; set; }

        [Display(Name = "Publish Date")]
        [Required(ErrorMessage = "Please make sure to enter publish date")]
        public DateTime? PublishDate { get; set; }

        [Display(Name = "No. of Pages")]
        [Required(ErrorMessage = "Please make sure to enter no. of pages")]
        [Range(5, double.MaxValue, ErrorMessage = "The book shall have at least 5 page")]
        public int? NoOfPages { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please make sure to select the genre")]
        public byte? GenreId { get; set; }

        public BookFormViewModel()
        {
            Id = 0;
        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            PublishDate = book.PublishDate;
            NoOfPages = book.NoOfPages;
            GenreId = book.GenreId;
        }
    }
}
