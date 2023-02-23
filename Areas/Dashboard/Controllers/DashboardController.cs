using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.BAL;

namespace ProgrammingCode.Areas.Dashboard.Controllers7
{
    [CheckAccess]
    [Area("Dashboard")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
