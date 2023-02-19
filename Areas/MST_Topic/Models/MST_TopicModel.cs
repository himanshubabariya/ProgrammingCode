using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.MST_Topic.Models
{
    public class MST_TopicModel
    {
        // ModelName: MST_ProgrammingLangaugeModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public string? F_TopicID { get; set; }

        public string? F_TopicName { get; set; }
        public string? F_UserName { get; set; }



        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "TopicID")]
        public int TopicID { get; set; }


        [Required, Display(Name = "TopicName")]
        public string? TopicName { get; set; }


        [Required, Display(Name = "TopicDescription")]
        public string? TopicDescription { get; set; }


        [Required, Display(Name = "Sequence")]
        public decimal Sequence { get; set; }


        [Required, Display(Name = "User")]
        public int UserID { get; set; }

        [Required, Display(Name = "UserName")]
        public String? UserName { get; set; }


        [Required, Display(Name = "View")]
        public int TopicView { get; set; }


        [Required, Display(Name = "Description")]
        public string? Description { get; set; }


        [Required, Display(Name = "MetaTitle")]
        public string? MetaTitle { get; set; }


        [Required, Display(Name = "MetaKeywords")]
        public string? MetaKeywords { get; set; }


        [Required, Display(Name = "MetaDescription")]
        public string? MetaDescription { get; set; }


        [Required, Display(Name = "MetaAuthor")]
        public string? MetaAuthor { get; set; }


        [Required, Display(Name = "MetaOgTitle")]
        public string? MetaOgTitle { get; set; }


        [Required, Display(Name = "MetaOgImage")]
        public string? MetaOgImage { get; set; }


        [Required, Display(Name = "MetaOgDescription")]
        public string? MetaOgDescription { get; set; }


        [Required, Display(Name = "MetaOgUrl")]
        public string? MetaOgUrl { get; set; }


        [Required, Display(Name = "MetaOgType")]
        public string? MetaOgType { get; set; }





        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }
    }
}
