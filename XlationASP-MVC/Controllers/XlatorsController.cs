using Microsoft.AspNetCore.Mvc;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    public class XlatorsController : Controller
    {
        private static readonly List<Xlator> XlatorList =
        [
            new Xlator() {Id = 1, Name = "Pouria"},
            new Xlator() {Id = 2, Name = "Zahra"},
            new Xlator() {Id = 3, Name = "Jafar"}
        ];

        [Route("xlators")]
        [HttpGet]
        public IActionResult Xlators()
        {
            var model = new XlatorViewModel { Xlators = XlatorList };

            return View(model);
        }

        [Route("xlators/details/{id?}")]
        [HttpGet]
        public IActionResult Details(int? id, int? queryId)
        {
            var effectiveId = id ?? queryId;

            var model = new XlatorViewModel
            {
                SelectedXlator = XlatorList.Find(x => x.Id == effectiveId)
            };

            if (model.SelectedXlator == null)
                return NotFound();

            return View("Xlators", model);
        }
    }
}
