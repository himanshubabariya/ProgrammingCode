using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;
using System.Net.NetworkInformation;

namespace ProgrammingCode.Controllers.ClientPanel
{
    public class ClientPanelController : Controller
    {
        static string? V_ProgramUrl;
        #region Index/HomePage
        public IActionResult Index()
        {
            ViewBag.LanguageList = DBConfig.dbLangauge.SelectAll().ToList();
            return View("HomePage");
        }
        #endregion
        #region LanguagePage
        [Route("Languages/{LanguageUrl}")]
        public IActionResult LanguageDetails(string? LanguageUrl)
        {
            ViewBag.LanguageUrl= LanguageUrl;
            ViewBag.LanguageDetails = DBConfig.dbLangauge.SelectByLanguageUrl(LanguageUrl).ToList();
            ViewBag.ProgramList = DBConfig.dbProgram.PropgramList(LanguageUrl).ToList();
            ViewBag.TopProgramList = DBConfig.dbProgram.TopPropgramList(LanguageUrl).ToList();
            return View("LanguageDetails");
        }
        #endregion
        #region ProgramPage
        [Route("Languages/{LanguageUrl}/Programs/{ProgramUrl}")]
        [Route("Programs/{ProgramUrl}")]
        [Route("Topics/{TopicID}/Programs/{ProgramUrl}")]
        public IActionResult ProgramDetails(string? ProgramUrl, string? LangaugeUrl)
        {
            
            V_ProgramUrl = ProgramUrl;
            ViewBag.LanguagesForslider = DBConfig.dbLangauge.SelectAll().ToList();
            ViewBag.TopicOnProgramUrl = DBConfig.dbTopic.SelectAllByProgramUrl(ProgramUrl).ToList();
            ViewBag.TestCase = DBConfig.dbProgramTestCase.SelectTestCaseByProgramUrl(ProgramUrl).ToList();
            ViewBag.Solution = DBConfig.dbSolution.SelectByProgramUrlLangaugeUrl(ProgramUrl, "Java").ToList();
            ViewBag.ProgramDetails = DBConfig.dbProgram.SelectByProgramUrl(ProgramUrl).ToList();
            return View("ProgramDetails");
        }
        #endregion
        #region SolutionByProgramUrlLangaugeUrl
        public IActionResult SolutionByProgramUrlLangaugeUrl(string? LanguageUrl)
        {
            ViewBag.Solution = DBConfig.dbSolution.SelectByProgramUrlLangaugeUrl(V_ProgramUrl, LanguageUrl).ToList();
            return PartialView("_SolutionByLangauge");
        }
        #endregion
        #region AllLanguages
        [Route("Languages")]
        
        public IActionResult AllLanguages()
        {
            ViewBag.AllLanguages = DBConfig.dbLangauge.SelectAll().ToList();
            return View("AllLanguages");
        }
        #endregion
        #region AllPrograms
        [Route("Programs")]
        public IActionResult AllPrograms()
        {
            ViewBag.ProgramNavList = DBConfig.dbProgram.PropgramNavList().ToList();
            ViewBag.TopProgramNavList = DBConfig.dbProgram.TopPropgramNavList().ToList();
            return View("AllPrograms");
        }
        #endregion
        #region AllTopics
        [Route("Topics")]
        public IActionResult AllTopics()
        {
            ViewBag.TopicList = DBConfig.dbTopic.SelectAll().ToList();
            return View("AllTopics");
        }
        #endregion
        #region TopicDetails
        [Route("Topics/{TopicID}")]
        public IActionResult TopicDetails(int? TopicID)
        {
            ViewBag.TopicID=TopicID;
            ViewBag.TopicDetails = DBConfig.dbTopic.SelectPk(TopicID).ToList();
            ViewBag.TopicRelatedProgramList = DBConfig.dbProgram.SelectByTopicID(TopicID).ToList();
            return View("TopicDetails");
        }
        #endregion
    }
}
