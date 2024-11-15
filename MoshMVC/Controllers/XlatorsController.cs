using Microsoft.AspNetCore.Mvc;
using XlationASP.Models;
using XlationASP.ViewModels;

namespace XlationASP.Controllers
{
    [Route("xlators")]
    public class XlatorsController : Controller
    {
        private static readonly List<Xlator> XlatorList = new List<Xlator>
        {
            new Xlator() {Id = 1, Name = "Pouria"},
            new Xlator() {Id = 2, Name = "Zahra"},
            new Xlator() {Id = 3, Name = "Jafar"}
        };

        [HttpGet]
        public IActionResult Xlators()
        {
            var model = new XlatorViewModel { Xlators = XlatorList };
            return View(model);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var model = new XlatorViewModel
            {
                SelectedXlator = XlatorList.Find(x => x.Id == id)
            };

            if (model == null)
                return NotFound();

            return View("Xlators", model);
        }
    }
}
