using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.MST_ProgrammingCode.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.DAL.MST.MST_ProgrammingLangauge;

namespace ProgrammingCode.Areas.MST_ProgrammingLangauge.Controllers
{
    [Area("MST_ProgrammingLangauge")]
    public class MST_ProgrammingLangaugeController : Controller
    {
        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(MST_ProgrammingLangaugeModel objProgrammingLangauge)
        {
            var vModel = DBConfig.LangaugeMST.SelectAll().ToList();
            return PartialView("_List", vModel);
        }
        #endregion
        
        #region _AddEdit
        public IActionResult _AddEdit(int? ProgrammingLangaugeID)
        {
            ViewBag.Action = "Add";

            if (ProgrammingLangaugeID != null)
            {
                ViewBag.Action = "Edit";

                var objProgrammingLangauge = DBConfig.LangaugeMST.SelectPk(ProgrammingLangaugeID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, MST_ProgrammingLangaugeModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, MST_ProgrammingLangaugeModel>(objProgrammingLangauge);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion

        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(MST_ProgrammingLangaugeModel objProgrammingLangauge)
        {
            if (objProgrammingLangauge.ProgrammingLangaugeID == 0)
            {
                var vReturn = DBConfig.LangaugeMST.Insert(objProgrammingLangauge);
            }
            else
            {
                DBConfig.LangaugeMST.Update(objProgrammingLangauge);
            }
            return Content(null);
        }
        #endregion        
        
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int ProgrammingLangaugeID)
        {
            DBConfig.LangaugeMST.Delete(ProgrammingLangaugeID);
            return Content(null);
        }
        #endregion
    }
}
