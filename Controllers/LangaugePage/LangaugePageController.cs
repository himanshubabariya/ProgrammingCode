using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.LangaugePage
{
	public class LangaugePageController : Controller
	{
		public IActionResult Index()
		{
            var programresult = DBConfig.dbProgram.SelectAll().ToList();
            return View(programresult);
          
		}
	}
}
