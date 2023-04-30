using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.PRO_ProgramTestCase.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.DAL.PRO.PRO_ProgramTestCase;
using ProgrammingCode.BAL;
using System.Web;
using System.Reflection;

namespace ProgrammingCode.Areas.PRO_ProgramTestCase.Controllers
{
    [CheckAccess]
    [Area("PRO_ProgramTestCase")]
   
    public class PRO_ProgramTestCase : Controller
    {
        PRO_ProgramTestCaseModel model = new PRO_ProgramTestCaseModel();
        #region index
        public IActionResult Index()
        {
            ViewBag.ProgramcomboList = DBConfig.dbProgram.SelectComboBoxProgram().ToList();     
            return View();
        }
        #endregion

        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(PRO_ProgramTestCaseModel ObjProgramTestCase,int? PN)
        {
            model = ObjProgramTestCase;
            int vPageNo = Convert.ToInt32(PN);

            if (!PN.HasValue)
            {
                vPageNo = 1;
            }
            var vModel = DBConfig.dbProgramTestCase.PageSelectForSearch(model.ProgramID, vPageNo, 10).ToList();
            ViewBag.SelectForSearchresult = DBConfig.dbProgramTestCase.SelectForSearch(model.ProgramID).ToList();
            int? vTotalRecords = ViewBag.SelectForSearchresult.Count;

            ViewBag.PagerModel = new PagedListPagerModel(vTotalRecords, vPageNo, 10);
            return PartialView("_List", vModel);
        }
        #endregion

        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int ProgramTestCaseID)
        {
            DBConfig.dbProgramTestCase.Delete(ProgramTestCaseID);
            return Content(null);
        }
        #endregion

        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(PRO_ProgramTestCaseModel obj_PRO_ProgramTestCase)
        {
            if (obj_PRO_ProgramTestCase.ProgramTestCaseID == 0)
            {
                var vReturn = DBConfig.dbProgramTestCase.Insert(obj_PRO_ProgramTestCase);
            }
            else
            {
                DBConfig.dbProgramTestCase.Update(obj_PRO_ProgramTestCase);
            }
            return RedirectToAction("Index");
        }
        #endregion     

        #region _AddEdit
        public IActionResult AddEdit(int? ProgramTestCaseID)
        {
            ViewBag.Action = "Add";
            ViewBag.ProgramcomboList = DBConfig.dbProgram.SelectComboBoxProgram().ToList();

            if (ProgramTestCaseID != null)
            {
                ViewBag.Action = "Edit";
              

                var objProgramTestCase = DBConfig.dbProgramTestCase.SelectPk(ProgramTestCaseID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result,PRO_ProgramTestCaseModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result,PRO_ProgramTestCaseModel>(objProgramTestCase);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
    }
}
