using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.DAL;
using System.Net.NetworkInformation;

namespace ProgrammingCode.Controllers.ClientPanel
{
    public class ClientPanelController : Controller
    {
        static string? V_ProgramUrl;
        static string? V_LanguageUrl;
        #region Index/HomePage

        public IActionResult Index()
        {
            ViewBag.LanguageList = DBConfig.dbLangauge.SelectForHomePage().ToList();
            return View("HomePage");
        }
        #endregion
        #region LanguagePage
        [Route("{LanguageUrl}")]
        [Route("Languages/{LanguageUrl}")]
        public IActionResult LanguageDetails(string? LanguageUrl)
        {
            TempData["SelectSolutionCount"] = DBConfig.dbSolution.SelectSolutionCount(LanguageUrl);
            ViewBag.LanguageUrl= LanguageUrl;
            V_LanguageUrl = LanguageUrl;
            ViewBag.LanguageDetails = DBConfig.dbLangauge.SelectByLanguageUrl(LanguageUrl).ToList();
            ViewBag.ProgramList = DBConfig.dbProgram.SelectByLanagueUrl(LanguageUrl).ToList();
            ViewBag.TopProgramList = DBConfig.dbProgram.SelectByLanagueUrlTop(LanguageUrl).ToList();
            return View("LanguageDetails");
        }
        #endregion
        #region ProgramPage
        [Route("{LanguageUrl}/{ProgramUrl}/ProgramDetails")]
        [Route("{ProgramUrl}/ProgramDetails")]
        public IActionResult ProgramDetails(string? ProgramUrl, string? LangaugeUrl)
        {
            V_ProgramUrl = ProgramUrl;
            ViewBag.LanguagesForslider = DBConfig.dbLangauge.SelectByProgramUrl(ProgramUrl).ToList();
            ViewBag.TopicOnProgramUrl = DBConfig.dbTopic.SelectAllByProgramUrl(ProgramUrl).ToList();
            ViewBag.TestCase = DBConfig.dbProgramTestCase.SelectTestCaseByProgramUrl(ProgramUrl).ToList();
            ViewBag.Solution = DBConfig.dbSolution.SelectByProgramUrlLangaugeUrl(ProgramUrl, V_LanguageUrl).ToList();
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
            ViewBag.AllLanguages = DBConfig.dbLangauge.SelectForHomePage().ToList();
            return View("AllLanguages");
        }
        #endregion
        #region AllPrograms
        [Route("Programs")]
        public IActionResult AllPrograms()
        {
            ViewBag.ProgramNavList = DBConfig.dbProgram.SelectAllProgramForClientPanel().ToList();
            ViewBag.TopProgramNavList = DBConfig.dbProgram.SelectAllTopProgramForClientPanel().ToList();
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
        [Route("Topics/{TopicUrl}")]
        public IActionResult TopicDetails(string TopicUrl)
        {
            TempData["ProgramCountonTopic"] = DBConfig.dbProgram.SelectCountByTopicUrl(TopicUrl);
            ViewBag.TopicDetails = DBConfig.dbTopic.SelectByTopicUrl(TopicUrl).ToList();
            ViewBag.TopicRelatedProgramList = DBConfig.dbProgram.SelectByTopicUrl(TopicUrl).ToList();
            return View("TopicDetails");
        }
        #endregion
    }
}
