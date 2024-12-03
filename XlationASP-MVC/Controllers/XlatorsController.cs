using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlationASP.Data;

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
    }
}
