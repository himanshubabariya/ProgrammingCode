    using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.PRO_ProgramSolution.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.BAL;
using ProgrammingCode.DAL.PRO.PRO_ProgramSolution;
using System.Data;

namespace ProgrammingCode.Areas.PRO_ProgramSolution.Controllers
{
    [CheckAccess]
    [Area("PRO_ProgramSolution")]
    public class PRO_ProgramSolutionController : Controller
    {
        #region Index 
        public IActionResult Index()
        {
            ViewBag.ProgramcomboList = DBConfig.dbProgram.SelectComboBoxProgram().ToList();
            ViewBag.SelectUser = DBConfig.dbUser.SelectComboBoxUser().ToList();
            ViewBag.ProgrammingLangaugecomboList = DBConfig.dbLangauge.SelectComboBoxProgrammingLangauge().ToList();
            return View();
        }
        #endregion
        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(PRO_ProgramSolutionModel Obj_PRO_ProgramSolution,int? PN)
        {
            int vPageNo = Convert.ToInt32(PN);

            if (!PN.HasValue)
            {
                vPageNo = 1;
            }
            var vModel = DBConfig.dbSolution.SelectBySolutionName(Obj_PRO_ProgramSolution.ProgramID,Obj_PRO_ProgramSolution.ProgrammingLangaugeID).ToList();
            ViewBag.AllPrograms = DBConfig.dbProgram.SelectAll().ToList();
            int? vTotalRecords = ViewBag.AllPrograms.Count;

            //ViewBag.PagedListPager = new PagedListPagerModel(vTotalRecords, vPageNo, 10);
            return PartialView("_List", vModel);
        }
        #endregion
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int ProgramSolutionID)
        {
            DBConfig.dbSolution.Delete(ProgramSolutionID); return Content(null);
        }
        #endregion
        #region _AddEdit
        public IActionResult AddEdit(int? ProgramSolutionID)
        {
            ViewBag.Action = "Add";
            ViewBag.ProgramcomboList = DBConfig.dbProgram.SelectComboBoxProgram().ToList();
            ViewBag.ProgrammingLangaugecomboList = DBConfig.dbLangauge.SelectComboBoxProgrammingLangauge().ToList(); 

            if (ProgramSolutionID != null)
            {
                ViewBag.Action = "Edit";

                var Obj_PRO_ProgramSolution = DBConfig.dbSolution.SelectPk(ProgramSolutionID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, PRO_ProgramSolutionModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, PRO_ProgramSolutionModel>(Obj_PRO_ProgramSolution);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(PRO_ProgramSolutionModel Obj_PRO_ProgramSolution)
        {   
            if (Obj_PRO_ProgramSolution.ProgramSolutionID == 0)
            {
                var vReturn = DBConfig.dbSolution.Insert(Obj_PRO_ProgramSolution);
            }
            else
            {
                DBConfig.dbSolution.Update(Obj_PRO_ProgramSolution);
            }
            return RedirectToAction("Index");
        }
        #endregion*/
        
    }
}
