using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.PRO_Program.Models;
using ProgrammingCode.Areas.SEC_User.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.DAL.SEC.SEC_User;
using System.Data;

namespace ProgrammingCode.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    public class SEC_UserController : Controller
    {
        #region Index 
        public IActionResult Index()
        {
            ViewBag.SelectUser = DBConfig.dbUser.SelectComboBoxUser().ToList();
            return View();
        }
        #endregion
        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(SEC_UserModel objUser)
        {
            var vModel = DBConfig.dbUser.SelectByUserID(objUser.UserID).ToList();
            return PartialView("_List", vModel);
        }
        #endregion
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int UserID)
        {
            DBConfig.dbUser.Delete(UserID); return Content(null);
        }
        #endregion
        #region _AddEdit
        public IActionResult _AddEdit(int? UserID)
        {
            ViewBag.Action = "Add";

            if (UserID != null)
            {
                ViewBag.Action = "Edit";

                var objUser = DBConfig.dbUser.SelectPk(UserID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, SEC_UserModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, SEC_UserModel>(objUser);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(SEC_UserModel objUser)
        {
            if (objUser.UserID == 0)
            {
                var vReturn = DBConfig.dbUser.Insert(objUser);
            }
            else
            {
                DBConfig.dbUser.Update(objUser);
            }
            return Content(null);
        }
        #endregion*/
        
    }
}
