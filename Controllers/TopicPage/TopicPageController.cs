using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;

namespace ProgrammingCode.Controllers.TopicPage
{
    public class TopicPageController : Controller
    {
        public IActionResult Index(int? TopicID)
        {
            ViewBag.TopicDetails = DBConfig.dbTopic.SelectPk(TopicID).ToList();
            ViewBag.TopicRelatedProgramList = DBConfig.dbProgram.SelectByTopicID(TopicID).ToList();
            return View();
        }
    }
}
