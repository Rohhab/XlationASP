using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
        public Book SelectedBook { get; set; }
    }
}
