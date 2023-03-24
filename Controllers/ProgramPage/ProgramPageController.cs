
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.ProgramPage
{
    public class ProgramPageController : Controller
    {
        static string? ProgramUrlForsolution;
        static string? LaqnguageUrlForsolution= "Java";
        public IActionResult Index(string? ProgramUrl, string? LangaugeUrl)
        {
            ProgramUrlForsolution = ProgramUrl;

		   ViewBag.LanguagesForslider= DBConfig.dbLangauge.SelectAll().ToList();
            ViewBag.TestCase = DBConfig.dbProgramTestCase.SelectTestCaseByProgramUrl(ProgramUrl).ToList();
            ViewBag.Solution = DBConfig.dbSolution.SelectByProgramUrlLangaugeUrl(ProgramUrlForsolution, LaqnguageUrlForsolution).ToList();
            var ProgramDetails = DBConfig.dbProgram.SelectByProgramUrl(ProgramUrl).ToList();
            return View(ProgramDetails); 
        }
        public IActionResult Programs_Nav()
       {
           ViewBag.ProgramNavList = DBConfig.dbProgram.PropgramNavList().ToList();
           ViewBag.TopProgramNavList = DBConfig.dbProgram.TopPropgramNavList().ToList();
           return View("Programs");
        }
        public IActionResult SolutionByProgramUrlLangaugeUrl(string? LanguageUrl)
        {
            ViewBag.Solution = DBConfig.dbSolution.SelectByProgramUrlLangaugeUrl(ProgramUrlForsolution, LanguageUrl).ToList();
            return View("_SolutionByLangauge");
        }
    }
}
