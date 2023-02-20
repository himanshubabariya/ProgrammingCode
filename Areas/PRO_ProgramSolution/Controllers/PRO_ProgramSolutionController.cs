﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.PRO_ProgramSolution.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.DAL.PRO.PRO_ProgramSolution;
using System.Data;

namespace ProgrammingCode.Areas.PRO_ProgramSolution.Controllers
{
    [Area("PRO_ProgramSolution")]
    public class PRO_ProgramSolutionController : Controller
    {
        #region Index 
        public IActionResult Index()
        {
            ViewBag.SelectUser = DBConfig.dbUser.SelectComboBoxUser().ToList();
            ViewBag.ProgrammingLangaugecomboList = DBConfig.dbLangauge.SelectComboBoxProgrammingLangauge().ToList();
            return View();
        }
        #endregion
        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(PRO_ProgramSolutionModel objSolution)
        {
            
            var vModel = DBConfig.dbSolution.SelectBySolutionName(objSolution.F_Defination, objSolution.UserID, objSolution.F_ProgramNumber, objSolution.ProgrammingLangaugeID).ToList();
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
        public IActionResult _AddEdit(int? ProgramSolutionID)
        {
            ViewBag.Action = "Add";
            ViewBag.ProgramcomboList = DBConfig.dbProgram.SelectComboBoxProgram().ToList();
            ViewBag.ProgrammingLangaugecomboList = DBConfig.dbLangauge.SelectComboBoxProgrammingLangauge().ToList(); 

            if (ProgramSolutionID != null)
            {
                ViewBag.Action = "Edit";

                var objSolution = DBConfig.dbSolution.SelectPk(ProgramSolutionID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, PRO_ProgramSolutionModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, PRO_ProgramSolutionModel>(objSolution);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion
        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(PRO_ProgramSolutionModel objSolution)
        {
            if (objSolution.ProgramSolutionID == 0)
            {
                var vReturn = DBConfig.dbSolution.Insert(objSolution);
            }
            else
            {
                DBConfig.dbSolution.Update(objSolution);
            }
            return Content(null);
        }
        #endregion*/
        
    }
}
