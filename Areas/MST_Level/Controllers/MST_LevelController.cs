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
            return View();
        }
        #endregion

        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(Models.PRO_ProgramTopic ObjLevel)
        {
            var vModel = DBConfig.LevelMST.SelectAll().ToList();
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
        public IActionResult _Save(Models.PRO_ProgramTopic objLevel)
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

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, Models.PRO_ProgramTopic>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, Models.PRO_ProgramTopic>(objLevel);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
    }
}
