using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.ProgramPage
{
    public class ProgramPageController : Controller
    {
        public IActionResult Index(string? ProgramUrl)
        {
            //ViewBag.Solution= DBConfig.dbProgram.SelectPk(ProgramID).ToList();
            ViewBag.TestCase = DBConfig.dbProgramTestCase.SelectTestCaseByProgramUrl(ProgramUrl).ToList();
            var ProgramDetails = DBConfig.dbProgram.SelectByProgramUrl(ProgramUrl).ToList();
            return View(ProgramDetails); 
        }
        public IActionResult Programs_Nav()
       {
           ViewBag.ProgramNavList = DBConfig.dbProgram.PropgramNavList().ToList();
           ViewBag.TopProgramNavList = DBConfig.dbProgram.TopPropgramNavList().ToList();
           return View("Programs");
        }
    }
}
