using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.AllTopics
{
    public class AllTopicsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TopicList = DBConfig.dbTopic.SelectAll().ToList();
            return View();
        }
    }
}
