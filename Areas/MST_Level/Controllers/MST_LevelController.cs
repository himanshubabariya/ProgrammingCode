using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.MST_Level.Models;

using ProgrammingCode.DAL;
using ProgrammingCode.DAL.MST.MST_Level;

namespace ProgrammingCode.Areas.MST_Level.Controllers
{
    [Area("MST_Level")]
    public class MST_LevelController : Controller
    {
       
        #region index
        public IActionResult Index()
        {
            ViewBag.SelectUser = DBConfig.UserSEC.SelectComboBoxUser().ToList();
            return View();
        }
        #endregion

        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(MST_LevelModel ObjLevel)
        {
            var vModel = DBConfig.LevelMST.SelectByLevelName(ObjLevel.F_LevelName,ObjLevel.UserID).ToList();
            return PartialView("_List", vModel);
        }
        #endregion

        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int LevelID)
        {
            DBConfig.LevelMST.Delete(LevelID);
            return Content(null);
        }
        #endregion

        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(MST_LevelModel objLevel)
        {
            if (objLevel.LevelID == 0)
            {
                var vReturn = DBConfig.LevelMST.Insert(objLevel);
            }
            else
            {
                DBConfig.LevelMST.Update(objLevel);
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

                var objLevel = DBConfig.LevelMST.SelectPk(LevelID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, MST_LevelModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, MST_LevelModel>(objLevel);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
    }
}
