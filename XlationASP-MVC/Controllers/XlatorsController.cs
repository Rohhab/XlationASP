using Microsoft.AspNetCore.Mvc;
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
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new NewXlatorViewModel { MembershipTypes = membershipTypes };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Xlator Xlator)
        {
            _context.Xlators.Add(Xlator);
            _context.SaveChanges();

            return RedirectToAction("Index", "Xlators");
        }
    }
}
