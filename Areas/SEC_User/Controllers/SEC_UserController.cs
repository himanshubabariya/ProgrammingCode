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
            ViewBag.SelectUser = DBConfig.UserSEC.SelectComboBoxUser().ToList();
            return View();
        }
        #endregion
        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(SEC_UserModel objUser)
        {
            var vModel = DBConfig.UserSEC.SelectByUserID(objUser.UserID).ToList();
            return PartialView("_List", vModel);
        }
        #endregion
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int UserID)
        {
            DBConfig.UserSEC.Delete(UserID); return Content(null);
        }
        #endregion
        #region _AddEdit
        public IActionResult _AddEdit(int? UserID)
        {
            ViewBag.Action = "Add";

            if (UserID != null)
            {
                ViewBag.Action = "Edit";

                var objUser = DBConfig.UserSEC.SelectPk(UserID).SingleOrDefault();

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
                var vReturn = DBConfig.UserSEC.Insert(objUser);
            }
            else
            {
                DBConfig.UserSEC.Update(objUser);
            }
            return Content(null);
        }
        #endregion*/
        
    }
}
