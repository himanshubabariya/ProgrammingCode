using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.MST_Level.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.BAL;
using ProgrammingCode.DAL.MST.MST_Level;

namespace ProgrammingCode.Areas.MST_Level.Controllers
{
    [CheckAccess]
    [Area("MST_Level")]
    public class MST_LevelController : Controller
    {
       
        #region index
        public IActionResult Index()
        {
            ViewBag.levelcomboList = DBConfig.dbLevel.SelectComboBoxLevel().ToList();
            ViewBag.SelectUser = DBConfig.dbUser.SelectComboBoxUser().ToList();
            return View();
        }
        #endregion

        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(MST_LevelModel Obj_MST_Level)
        {
            var vModel = DBConfig.dbLevel.SelectByLevelName(Obj_MST_Level.LevelID).ToList();
            return PartialView("_List", vModel);
        }
        #endregion

        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int LevelID)
        {
            DBConfig.dbLevel.Delete(LevelID);
            return Content(null);
        }
        #endregion

        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(MST_LevelModel Obj_MST_Level)
        {
            if (Obj_MST_Level.LevelID == 0)
            {
                var vReturn = DBConfig.dbLevel.Insert(Obj_MST_Level);
            }
            else
            {
                DBConfig.dbLevel.Update(Obj_MST_Level);
            }
            return Content(null);
        }
        #endregion     

        #region _AddEdit
        public IActionResult _AddEdit(int? LevelID)
        {
            ViewBag.Action = "Add";

            if (LevelID != null)
            {
                /*ViewBag.Action = "Edit";*/

                var Obj_MST_Level = DBConfig.dbLevel.SelectPk(LevelID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, MST_LevelModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, MST_LevelModel>(Obj_MST_Level);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
    }
}
