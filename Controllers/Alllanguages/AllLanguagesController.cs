using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.Alllanguages
{
    public class AllLanguagesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.AllLanguages = DBConfig.dbLangauge.SelectAll().ToList();
            return View();
        }
    }
}
