 using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.LangaugePage
{
	public class LangaugePageController : Controller
	{
		public IActionResult Index(string? LanguageUrl)
		{
            var programresult = DBConfig.dbLangauge.SelectByLanguageUrl(LanguageUrl).ToList();
			ViewBag.ProgramList = DBConfig.dbProgram.PropgramList(LanguageUrl).ToList();
            ViewBag.TopProgramList = DBConfig.dbProgram.TopPropgramList(LanguageUrl).ToList();
            return View(programresult);         
		}
	}
}
