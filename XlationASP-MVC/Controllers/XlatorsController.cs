﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlationASP.Data;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    public class XlatorsController : Controller
    {
        private readonly DomainDbContext _context;
        public XlatorsController(DomainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.Xlators.Include(x => x.MembershipType).ToList();

            return View(model);
        }

        [Route("xlators/details/{id?}")]
        [HttpGet]
        public IActionResult Details(int? id, int? queryId)
        {
            var effectiveId = id ?? queryId;

            var model = _context.Xlators.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == effectiveId);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["Title"] = "New Xlator";

            var membershipTypes = _context.MembershipType.ToList();

            var viewModel = new XlatorFormViewModel { MembershipTypes = membershipTypes };
            return View("XlatorForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Xlator Xlator)
        {
            if (Xlator.Id == 0)
                _context.Xlators.Add(Xlator);
            else
            {
                var xlatorInDb = _context.Xlators.Single(x => x.Id == Xlator.Id);

                xlatorInDb.Name = Xlator.Name;
                xlatorInDb.Birthdate = Xlator.Birthdate;
                xlatorInDb.IsSubscribedToNewsLetter = Xlator.IsSubscribedToNewsLetter;
                xlatorInDb.MembershipTypeId = Xlator.MembershipTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Xlators");
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit Xlator";
            var xlator = _context.Xlators.SingleOrDefault(x => x.Id == id);

            if (xlator == null)
                return NotFound();

            var viewModel = new XlatorFormViewModel
            {
                Xlator = xlator,
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View("XlatorForm", viewModel);
        }
    }
}