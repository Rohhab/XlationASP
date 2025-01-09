using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XlationASP.Data;
using XlationASP.Models;

namespace XlationASP.Controllers
{
    public class XlationAgreementsController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DomainDbContext _domainDbContext;

        public XlationAgreementsController(ApplicationDbContext applicationDbContext, DomainDbContext domainDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _domainDbContext = domainDbContext;
        }

        [Authorize(Roles = "Admin, Xlator")]
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new XlationAgreement()
            {
                Xlators = _domainDbContext.Xlators.ToList(),
                Books = _domainDbContext.Books.ToList()
            };

            return View(viewModel);
        }
    }
}
