using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XlationASP.Data;
using XlationASP.Dtos;
using XlationASP.Models;

namespace XlationASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(DomainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/books
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            return Ok(booksDto);
        }

        // GET /api/books/id
        [HttpGet("{id}")]
        public IActionResult GetBooks(int id)
        {
            var bookInDb = _context.Books.Find(id);

            if (bookInDb == null)
                return NotFound("Book not found.");

            var bookDto = _mapper.Map<BookDto>(bookInDb);

            return Ok(bookDto);
        }

        // POST /api/books
        [HttpPost]
        public IActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = _mapper.Map<Book>(bookDto);

            _context.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;

            var uri = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{bookDto.Id}");

            return Created(uri, bookDto);
        }

        // PUT /api/books/id
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookInDb = _context.Books.Find(id);

            if (bookInDb == null)
                return NotFound("Book not found");

            _mapper.Map(bookDto, bookInDb);
            _context.SaveChanges();

            bookDto.Id = bookInDb.Id;

            return Ok(bookDto);
        }

        // DELETE /api/books/id
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.Find(id);

            if (bookInDb == null)
                return NotFound("Book not found");

            _context.Remove(bookInDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
