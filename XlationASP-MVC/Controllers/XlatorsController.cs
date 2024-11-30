using Microsoft.AspNetCore.Mvc;
using XlationASP.Data;
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

        [Route("xlators")]
        [HttpGet]
        public IActionResult Xlators()
        {
            var model = new XlatorViewModel
            {
                Xlators = _context.Xlators.ToList()
            };

            return View(model);
        }

        [Route("xlators/details/{id?}")]
        [HttpGet]
        public IActionResult Details(int? id, int? queryId)
        {
            var effectiveId = id ?? queryId;

            var model = new XlatorViewModel
            {
                SelectedXlator = _context.Xlators.SingleOrDefault(x => x.Id == effectiveId)
            };

            if (model == null)
                return NotFound();

            return View("Xlators", model);
        }
    }
}
