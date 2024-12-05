using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre>? Genre { get; set; }
        public Book? Book { get; set; }
    }
}
