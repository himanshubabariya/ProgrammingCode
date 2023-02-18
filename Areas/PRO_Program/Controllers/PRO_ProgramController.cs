using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.MST_ProgrammingCode.Models;
using ProgrammingCode.Areas.PRO_Program.Models;
using ProgrammingCode.Areas.SEC_User.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.DAL.PRO.PRO_Program;
using System.Data;

namespace ProgrammingCode.Areas.PRO_Program.Controllers
{
    [Area("PRO_Program")]
    public class PRO_ProgramController : Controller
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
        public IActionResult _SearchResult(PRO_ProgramModel objProgram)
        {
            var vModel = DBConfig.ProgramPRO.SelectAll().ToList();
            return PartialView("_List", vModel);
        }
        #endregion
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int ProgramID)
        {
            DBConfig.ProgramPRO.Delete(ProgramID); return Content(null);
        }
        #endregion
        #region _AddEdit
        public IActionResult _AddEdit(int? ProgramID)
        {
            ViewBag.Action = "Add";

            if (ProgramID != null)
            {
                ViewBag.Action = "Edit";

                var objProgram = DBConfig.ProgramPRO.SelectPk(ProgramID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, PRO_ProgramModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, PRO_ProgramModel>(objProgram);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(PRO_ProgramModel objProgram)
        {
            if (objProgram.ProgramID == 0)
            {
                var vReturn = DBConfig.ProgramPRO.Insert(objProgram);
            }
            else
            {
                DBConfig.ProgramPRO.Update(objProgram);
            }
            return Content(null);
        }
        #endregion
        
    }
}
