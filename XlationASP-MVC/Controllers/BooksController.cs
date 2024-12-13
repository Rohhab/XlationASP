using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlationASP.Data;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    public class BooksController : Controller
    {
        private readonly DomainDbContext _context;
        public BooksController(DomainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.Books.Include(b => b.Genre).ToList();

            return View(model);
        }

        [Route("books/details/{id?}")]
        [HttpGet]
        public IActionResult Details(int? id, int? queryId)
        {
            var effectiveId = id ?? queryId;

            var model = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["Title"] = "New Book";

            var genres = _context.Genre.ToList();

            var ViewModel = new BookFormViewModel
            {
                Genre = genres
            };
            return View("BookForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Book Book)
        {
            if (Book.Id == 0)
                _context.Books.Add(Book);
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == Book.Id);

                bookInDb.Title = Book.Title;
                bookInDb.PublishDate = Book.PublishDate;
                bookInDb.Genre = Book.Genre;
                bookInDb.NoOfPages = Book.NoOfPages;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit Book";
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            var ViewModel = new BookFormViewModel
            {
                Book = book,
                Genre = _context.Genre.ToList()
            };
            return View("BookForm", ViewModel);
        }
    }
}
