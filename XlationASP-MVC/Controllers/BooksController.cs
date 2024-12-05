using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlationASP.Data;

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
    }
}
