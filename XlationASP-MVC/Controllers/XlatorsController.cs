using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
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
            if (User.IsInRole(RoleName.Admin))
                return View("List");

            return View("LimitedList");
        }

        [Route("xlators/details/{id?}")]
        [HttpGet]
        public IActionResult Details(int? id, int? queryId)
        {
            var effectiveId = id ?? queryId;

            var model = _context
                .Xlators.Include(x => x.MembershipType)
                .SingleOrDefault(x => x.Id == effectiveId);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Xlator")]
        public IActionResult New()
        {
            ViewData["Title"] = "New Xlator";

            var viewModel = new XlatorFormViewModel
            {
                MembershipTypes = [.. _context.MembershipType],
            };

            return View("XlatorForm", viewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit Xlator";
            var xlator = _context.Xlators.SingleOrDefault(x => x.Id == id);

            if (xlator == null)
                return NotFound();

            var viewModel = new XlatorFormViewModel(xlator)
            {
                MembershipTypes = [.. _context.MembershipType],
            };

            return View("XlatorForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Xlator xlator)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Save Xlator";

                var viewModel = new XlatorFormViewModel(xlator)
                {
                    MembershipTypes = [.. _context.MembershipType],
                };

                return View("XlatorForm", viewModel);
            }

            if (xlator.Id == 0)
            {
                _context.Xlators.Add(xlator);
            }
            else
            {
                var xlatorInDb = _context.Xlators.Single(x => x.Id == xlator.Id);

                xlatorInDb.Name = xlator.Name;
                xlatorInDb.Birthdate = xlator.Birthdate;
                xlatorInDb.IsSubscribedToNewsLetter = xlator.IsSubscribedToNewsLetter;
                xlatorInDb.MembershipTypeId = xlator.MembershipTypeId;
                xlatorInDb.Email = xlator.Email;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Xlators");
        }

    }
}
