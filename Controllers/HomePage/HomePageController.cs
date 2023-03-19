using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;
using System.Data;

namespace ProgrammingCode.Controllers.HomePage
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
			var Langauge = DBConfig.dbLangauge.SelectAll().ToList();
			return View(Langauge);
		
        }

    }
}
