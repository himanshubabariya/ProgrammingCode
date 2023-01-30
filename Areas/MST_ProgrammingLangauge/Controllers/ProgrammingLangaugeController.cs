using Microsoft.AspNetCore.Mvc;

namespace ProgrammingCode.Areas.MST_ProgrammingLangauge.Controllers
{
    [Area("MST_ProgrammingLangauge")]
    public class ProgrammingLangaugeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
