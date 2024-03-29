﻿using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.BAL;
using ProgrammingCode.DAL;
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
        #region LanguageDetails
        [Route("{LanguageUrl}")]
        [Route("Languages/{LanguageUrl}")]
        public IActionResult LanguageDetails(string? LanguageUrl,int?  PN)
        {
            TempData["SelectSolutionCount"] = DBConfig.dbSolution.SelectSolutionCount(LanguageUrl);
            ViewBag.LanguageUrl = LanguageUrl;
            ViewBag.AllLanguages = DBConfig.dbLangauge.SelectForHomePage().ToList();
            ViewBag.LanguageDetails = DBConfig.dbLangauge.SelectByLanguageUrl(LanguageUrl).ToList();
  
            ViewBag.ProgramList = DBConfig.dbProgram.SelectPageForProhrambyLanguageUrl(LanguageUrl, 1, 10).ToList();
            ViewBag.allprogram = DBConfig.dbProgram.SelectByLanagueUrl(LanguageUrl);
            int? vTotalRecords = ViewBag.allprogram.Count;
            var Vmodel = new PagedListPagerModel(vTotalRecords, 1, 10);
            ViewBag.TopProgramList = DBConfig.dbProgram.SelectByLanagueUrlTop(LanguageUrl).ToList();
            return View("LanguageDetails", Vmodel);
        }
        #endregion
        #region ProgramListForLanguageDetails
        public IActionResult ProgramListForLanguageDetails(string LanguageUrl, int? PN)
        {
            int? vPageNo = Convert.ToInt32(PN);
            if (!PN.HasValue)
            {
                vPageNo = 1;
            }
            ViewBag.LanguageUrl = LanguageUrl;
            ViewBag.ProgramList = DBConfig.dbProgram.SelectPageForProhrambyLanguageUrl(LanguageUrl, vPageNo, 10).ToList();
            ViewBag.allprogram = DBConfig.dbProgram.SelectByLanagueUrl(LanguageUrl);
            int? vTotalRecords = ViewBag.allprogram.Count;

            var Vmodel = new PagedListPagerModel(vTotalRecords, vPageNo, 10);

            
            return PartialView("ProgramListLanguageDetails", Vmodel);
        }
        #endregion
        string str = null;
        #region ProgramPage
        [Route("{LanguageUrl}/{ProgramUrl}/ProgramDetails")]
        [Route("{ProgramUrl}/ProgramDetails")]
        public IActionResult ProgramDetails(string? ProgramUrl, string? LanguageUrl)
        {
            V_ProgramUrl = ProgramUrl;
            ViewBag.LanguageUrl = LanguageUrl;
            ViewBag.AllLanguages = DBConfig.dbLangauge.SelectForHomePage().ToList();
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
        [Route("Programs/{TopicUrl}")]  
        public IActionResult AllPrograms(string? TopicUrl,int? PN)
        {
            //int vPageNo = Convert.ToInt32(PN);

            //if (!PN.HasValue)
            //{
            //    vPageNo = 1;
            //}
            ViewBag.TopicUrl = TopicUrl;
            ViewBag.ProgramNavList = DBConfig.dbProgram.SelectAllProgramForClientPanel(1, 10).ToList();
            ViewBag.TopicDetails = DBConfig.dbTopic.SelectByTopicUrl(TopicUrl).ToList();
            ViewBag.allprogram = DBConfig.dbProgram.SelectAll();
            int? vTotalRecords = ViewBag.allprogram.Count;
            ViewBag.TopicList = DBConfig.dbTopic.SelectAll().ToList();
            
            if (TopicUrl!=null)
            {
                ViewBag.ProgramNavList = DBConfig.dbProgram.SelectPageForProgramByTopicUrl(TopicUrl, 1, 10).ToList();
                ViewBag.relatedProgrms = DBConfig.dbProgram.SelectByTopicUrl(TopicUrl).ToList();
                vTotalRecords = ViewBag.relatedProgrms.Count;
            }
            var Vmodel = new PagedListPagerModel(vTotalRecords, 1, 10);
   
            ViewBag.TopProgramNavList = DBConfig.dbProgram.SelectAllTopProgramForClientPanel().ToList();
            return View("AllPrograms",Vmodel);
        }
        #endregion
        #region ProgramListForAllProgram
        public IActionResult ProgramListAllProgram(string? TopicUrl, int? PN)
        {
            int vPageNo = Convert.ToInt32(PN);

            if (!PN.HasValue)
            {
                vPageNo = 1;
            }
            ViewBag.TopicUrl = TopicUrl;
            ViewBag.ProgramNavList = DBConfig.dbProgram.SelectAllProgramForClientPanel(vPageNo, 10).ToList();
            ViewBag.TopicDetails = DBConfig.dbTopic.SelectByTopicUrl(TopicUrl).ToList();
            ViewBag.allprogram = DBConfig.dbProgram.SelectAll();
            int? vTotalRecords = ViewBag.allprogram.Count;
         

            if (TopicUrl != null)
            {
                ViewBag.ProgramNavList = DBConfig.dbProgram.SelectPageForProgramByTopicUrl(TopicUrl, vPageNo, 10).ToList();
                ViewBag.relatedProgrms = DBConfig.dbProgram.SelectByTopicUrl(TopicUrl).ToList();
                vTotalRecords = ViewBag.relatedProgrms.Count;
            }
            var Vmodel = new PagedListPagerModel(vTotalRecords, vPageNo, 10);
            return PartialView("ProgramPagePrograms", Vmodel);
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
        [Route("Topics/{TopicUrl}/")]
        public IActionResult TopicDetails(string TopicUrl, int? PN)
        {
            //int vPageNo = Convert.ToInt32(PN);

            //if (!PN.HasValue)
            //{
            //    vPageNo = 1;
            //}
            ViewBag.TopicUrl= TopicUrl;
            TempData["ProgramCountonTopic"] = DBConfig.dbProgram.SelectCountByTopicUrl(TopicUrl);
            ViewBag.TopicDetails = DBConfig.dbTopic.SelectByTopicUrl(TopicUrl).ToList();
            ViewBag.TopicRelatedProgram = DBConfig.dbProgram.SelectByTopicUrl(TopicUrl).ToList();
            ViewBag.TopicRelatedProgramList = DBConfig.dbProgram.SelectPageForProgramByTopicUrl(TopicUrl,1,10).ToList();
            ViewBag.TopicList = DBConfig.dbTopic.SelectAll().ToList();
            int? vTotalRecords = ViewBag.TopicRelatedProgram.Count;

            var Vmodel = new PagedListPagerModel(vTotalRecords, 1, 10);
            return View("TopicDetails",Vmodel);
        }
        #endregion
        #region ProgramListForTopicDetails
        public IActionResult ProgramListTopicDetails(string TopicUrl, int? PN)
        {
            int vPageNo = Convert.ToInt32(PN);

            if (!PN.HasValue)
            {
                vPageNo = 1;
            }
            @ViewBag.TopicUrl = TopicUrl;
            ViewBag.TopicRelatedProgram = DBConfig.dbProgram.SelectByTopicUrl(TopicUrl).ToList();
            ViewBag.TopicRelatedProgramList = DBConfig.dbProgram.SelectPageForProgramByTopicUrl(TopicUrl, vPageNo, 10).ToList();
            ViewBag.TopicList = DBConfig.dbTopic.SelectAll().ToList();
            int? vTotalRecords = ViewBag.TopicRelatedProgram.Count;

            var Vmodel = new PagedListPagerModel(vTotalRecords, vPageNo, 10);
            return PartialView("ProgramListTopicDetails", Vmodel);
        }
        #endregion

    }
}
