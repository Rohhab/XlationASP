using Microsoft.AspNetCore.Mvc;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    [Route("books")]
    public class BooksController : Controller
    {
        private static readonly List<Book> BookList = new List<Book>
        {
            new Book {Id = 1, Title = "Chernobyl"},
            new Book {Id = 2, Title = "Fourcade"},
            new Book {Id = 3 , Title = "Engineering"}
        };

        [HttpGet]
        public IActionResult Books()
        {
            var model = new BookViewModel
            {
                Books = BookList
            };

            return View(model);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var model = new BookViewModel
            {
                SelectedBook = BookList.Find(b => b.Id == id)
            };

            if (model == null)
                return NotFound();

            return View("Books", model);
        }
    }
}
