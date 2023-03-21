using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.LangaugePage
{
	public class LangaugePageController : Controller
	{
		public IActionResult Index(int ProgrammingLangaugeID)
		{
            var programresult = DBConfig.dbLangauge.SelectPk(ProgrammingLangaugeID).ToList();
			ViewBag.ProgramList = DBConfig.dbProgram.PropgramList().ToList();
            ViewBag.TopProgramList = DBConfig.dbProgram.TopPropgramList().ToList();
            return View(programresult);         
		}
	}
}
