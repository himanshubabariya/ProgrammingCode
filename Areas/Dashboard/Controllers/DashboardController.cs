using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.BAL;

namespace ProgrammingCode.Areas.Dashboard.Controllers
{
    [CheckAccess]
    [Area("Dashboard")]
    [Route("Dashboard")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
