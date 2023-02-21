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
            ViewBag.ProgrammingLangaugecomboList = DBConfig.dbLangauge.SelectComboBoxProgrammingLangauge().ToList();
            ViewBag.SelectUser = DBConfig.dbUser.SelectComboBoxUser().ToList();
            return View();
        }
        #endregion

        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(MST_ProgrammingLangaugeModel Obj_MST_ProgrammingLangauge)
        {
            var vModel = DBConfig.dbLangauge.SelectByProgrammingLangaugeName(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeID, Obj_MST_ProgrammingLangauge.UserID).ToList();
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

                var Obj_MST_ProgrammingLangauge = DBConfig.dbLangauge.SelectPk(ProgrammingLangaugeID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, MST_ProgrammingLangaugeModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, MST_ProgrammingLangaugeModel>(Obj_MST_ProgrammingLangauge);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion

        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(MST_ProgrammingLangaugeModel Obj_MST_ProgrammingLangauge)
        {
            #region PhotoPath
            if (Obj_MST_ProgrammingLangauge.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, Obj_MST_ProgrammingLangauge.File.FileName);
                Obj_MST_ProgrammingLangauge.ProgrammingLangaugeLogo = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + Obj_MST_ProgrammingLangauge.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    Obj_MST_ProgrammingLangauge.File.CopyTo(stream);
                }

            }
            #endregion
            if (Obj_MST_ProgrammingLangauge.ProgrammingLangaugeID == 0)
            {
                var vReturn = DBConfig.dbLangauge.Insert(Obj_MST_ProgrammingLangauge);                                                
            }
            else
            {
                DBConfig.dbLangauge.Update(Obj_MST_ProgrammingLangauge);
            }
            return Content(null);
        }
        #endregion        
        
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int ProgrammingLangaugeID)
        {
            DBConfig.dbLangauge.Delete(ProgrammingLangaugeID);
            return Content(null);
        }
        #endregion

       
    }
}
