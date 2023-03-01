using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.MST_Topic.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.BAL;
using ProgrammingCode.DAL.MST.MST_Topic;


namespace ProgrammingCode.Areas.MST_Topic.Controllers
{
   // [CheckAccess]
    [Area("MST_Topic")]
    public class MST_TopicController : Controller
    {
        #region Index
        public IActionResult Index()
        {
            ViewBag.TopiccomboList = DBConfig.dbTopic.SelectComboBoxTopic().ToList();
            return View();
        }
        #endregion

        #region _SearchResult
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(MST_TopicModel Obj_MST_Topic)
        {
            var vModel = DBConfig.dbTopic.SelectByTopicName(Obj_MST_Topic.TopicID).ToList();
            return PartialView("_List", vModel);
        }
        #endregion

        #region _AddEdit
        public IActionResult AddEdit(int? TopicID)
        {
            ViewBag.Action = "Add";

            if (TopicID != null)
            {
                ViewBag.Action = "Edit";

                var Obj_MST_Topic = DBConfig.dbTopic.SelectPk(TopicID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, MST_TopicModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, MST_TopicModel>(Obj_MST_Topic);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion

        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(MST_TopicModel Obj_MST_Topic)
        {
            #region PhotoPath2 meta og Image
            if (Obj_MST_Topic.File2 != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, Obj_MST_Topic.File2.FileName);
                Obj_MST_Topic.MetaOgImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + Obj_MST_Topic.File2.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    Obj_MST_Topic.File2.CopyTo(stream);
                }

            }
            #endregion
            if (Obj_MST_Topic.TopicID == 0)
            {
                var vReturn = DBConfig.dbTopic.Insert(Obj_MST_Topic);
            }
            else
            {
                DBConfig.dbTopic.Update(Obj_MST_Topic);
            }
            return Content(null);
        }
        #endregion

        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int TopicID)
        {
            DBConfig.dbTopic.Delete(TopicID);
            return Content(null);
        }
        #endregion
    }
}
