using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.BAL;
using ProgrammingCode.Areas.PRO_Program.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.DAL.PRO.PRO_Program;
using System.Data;
using System.Data.SqlClient;
using static ProgrammingCode.Areas.MST_Level.Models.MST_LevelModel;
using ProgrammingCode.Areas.PRO_ProgramSolution.Models;

namespace ProgrammingCode.Areas.PRO_Program.Controllers
{
    [CheckAccess]
    [Area("PRO_Program")]
    public class PRO_ProgramController : Controller
    {
        PRO_ProgramModel model = new PRO_ProgramModel();
        #region Index 
        public IActionResult Index()
        {
            ViewBag.levelcomboList = DBConfig.dbLevel.SelectComboBoxLevel().ToList();
            ViewBag.topiccomboList = DBConfig.dbTopic.SelectComboBoxTopic().ToList();
            return View();
        }
        #endregion
        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult _SearchResult(PRO_ProgramModel Obj_PRO_Program, int? PN)
        {
            model = Obj_PRO_Program;
            int vPageNo = Convert.ToInt32(PN);

            if (!PN.HasValue)
            {
                vPageNo = 1;
            }
            var vModel = DBConfig.dbProgram.PageSelectForSearch(model.F_ProgramNumber, model.F_LevelID, model.F_TopicID, model.F_Defination, vPageNo, 10).ToList();
            ViewBag.SelectForSearchresult = DBConfig.dbProgram.SelectForSearch(Obj_PRO_Program.F_ProgramNumber, Obj_PRO_Program.F_LevelID, Obj_PRO_Program. F_TopicID, Obj_PRO_Program.F_Defination).ToList();
            int? vTotalRecords = ViewBag.SelectForSearchresult.Count;

            ViewBag.PagerModel = new PagedListPagerModel(vTotalRecords, vPageNo, 10);
            return PartialView("_List", vModel);
        }
        #endregion
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int ProgramID)
        {
            DBConfig.dbProgram.Delete(ProgramID); return Content(null);
        }
        #endregion
        #region _AddEdit
        public IActionResult AddEdit(int? ProgramID)
        {
            ViewBag.Action = "Add";
            List<int> preselectedTopicIDs = DBConfig.dbProgram.GetPreselectedTopicIDs(ProgramID);

            ViewBag.PreselectedTopicIDs = preselectedTopicIDs;
            
            ViewBag.levelcomboList = DBConfig.dbLevel.SelectComboBoxLevel().ToList();
			ViewBag.topiccomboList = DBConfig.dbTopic.SelectComboBoxTopic().ToList(); 

			if (ProgramID != null)
            {
                ViewBag.Action = "Edit";

                var objProgram = DBConfig.dbProgram.SelectPk(ProgramID).SingleOrDefault();  

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
        public IActionResult _Save(PRO_ProgramModel Obj_PRO_Program)
        {
            #region PhotoPath2 meta og Image
            if (Obj_PRO_Program.File2 != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, Obj_PRO_Program.File2.FileName);
                Obj_PRO_Program.MetaOgImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + Obj_PRO_Program.File2.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    Obj_PRO_Program.File2.CopyTo(stream);
                }

            }
            else
            {
                ViewBag.program = DBConfig.dbProgram.SelectAll().ToList();
                if (ViewBag.program.Count > 0)
                {
                    Obj_PRO_Program.MetaOgImage = ViewBag.program[0].MetaOgImage;
                }
            }
            #endregion
            if (Obj_PRO_Program.ProgramID == 0)
            {
                var vReturn = DBConfig.dbProgram.Insert(Obj_PRO_Program);
            }
            else
            {
                DBConfig.dbProgram.Update(Obj_PRO_Program);
            }
            return RedirectToAction("Index");
        }
        #endregion


        
    }
}
