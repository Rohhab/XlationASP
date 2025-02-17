﻿using Microsoft.AspNetCore.Authorization;
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
            //var model = _context.Books.Include(b => b.Genre).ToList();
            if (User.IsInRole("Admin"))
                return View("List");

            return View("LimitedList");
        }

        [Route("books/details/{id?}")]
        [HttpGet]
        public IActionResult Details(int? id, int? queryId)
        {
            var effectiveId = id ?? queryId;

            var model = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == effectiveId);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Xlator")]
        public IActionResult New()
        {
            ViewData["Title"] = "New Book";

            var ViewModel = new BookFormViewModel
            {
                Genre = [.. _context.Genre]
            };

            return View("BookForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Save Book";

                var viewModel = new BookFormViewModel(book)
                {
                    Genre = [.. _context.Genre]
                };

                return View("BookForm", viewModel);
            }

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _context.Books.Add(book);
            }
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                bookInDb.Title = book.Title;
                bookInDb.PublishDate = book.PublishDate;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NoOfPages = book.NoOfPages;
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

            var ViewModel = new BookFormViewModel(book)
            {
                Genre = [.. _context.Genre]
            };

            return View("BookForm", ViewModel);
        }
    }
}
