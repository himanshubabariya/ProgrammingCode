using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingCode.Areas.MST_Topic.Models;
using ProgrammingCode.DAL;
using ProgrammingCode.DAL.MST.MST_Topic;

namespace ProgrammingCode.Areas.MST_Topic.Controllers
{
    [Area("MST_Topic")]
    public class MST_TopicController : Controller
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
        public IActionResult _SearchResult(MST_TopicModel objTopic)
        {
            var vModel = DBConfig.TopicMST.SelectByTopicName(objTopic.F_TopicName, objTopic.F_UserName).ToList();
            return PartialView("_List", vModel);
        }
        #endregion

        #region _AddEdit
        public IActionResult _AddEdit(int? TopicID)
        {
            ViewBag.Action = "Add";

            if (TopicID != null)
            {
                ViewBag.Action = "Edit";

                var objTopic = DBConfig.TopicMST.SelectPk(TopicID).SingleOrDefault();

                Mapper.Initialize(config => config.CreateMap<SelectPk_Result, MST_TopicModel>());
                var vModel = AutoMapper.Mapper.Map<SelectPk_Result, MST_TopicModel>(objTopic);

                return PartialView(vModel);
            }
            return PartialView();
        }
        #endregion

        #region _Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(MST_TopicModel objTopic)
        {
            if (objTopic.TopicID == 0)
            {
                var vReturn = DBConfig.TopicMST.Insert(objTopic);
            }
            else
            {
                DBConfig.TopicMST.Update(objTopic);
            }
            return Content(null);
        }
        #endregion

        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int TopicID)
        {
            DBConfig.TopicMST.Delete(TopicID);
            return Content(null);
        }
        #endregion
    }
}
