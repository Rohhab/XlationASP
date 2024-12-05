using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class BookDetailsViewModel
    {
        public IEnumerable<Genre>? Genre { get; set; }
        public Book? Book { get; set; }
    }
}
