using Microsoft.AspNetCore.Mvc;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    public class BooksController : Controller
    {
        private static readonly List<Book> BookList =
        [
            new Book {Id = 1, Title = "Chernobyl"},
            new Book {Id = 2, Title = "Fourcade"},
            new Book {Id = 3 , Title = "Engineering"}
        ];

        [Route("books")]
        [HttpGet]
        public IActionResult Books()
        {
            var model = new BookViewModel
            {
                Books = BookList
            };

            return View(model);
        }

        [Route("books/details/{id?}")]
        [HttpGet]
        public IActionResult Details(int? id, int? queryId)
        {
            var effectiveId = id ?? queryId;

            var model = new BookViewModel
            {
                SelectedBook = BookList.Find(b => b.Id == effectiveId)
            };

            if (model.SelectedBook == null)
                return NotFound();

            return View("Books", model);
        }
    }
}
