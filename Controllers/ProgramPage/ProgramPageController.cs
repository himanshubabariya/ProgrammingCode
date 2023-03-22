using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.ProgramPage
{
    public class ProgramPageController : Controller
    {
        public IActionResult Index(int ProgramID)
        {
            ViewBag.Solution= DBConfig.dbProgram.SelectPk(ProgramID).ToList();
			var ProgramDetails = DBConfig.dbProgram.SelectPk(ProgramID).ToList();
            return View(ProgramDetails);
        }
        public IActionResult Programs_Nav()
       {
           ViewBag.ProgramList = DBConfig.dbProgram.PropgramNavList().ToList();
           ViewBag.TopProgramList = DBConfig.dbProgram.TopPropgramNavList().ToList();
           return View();
        }
    }
}
