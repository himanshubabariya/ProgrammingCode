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



       
        public decimal? Sequence { get; set; }
        [Required, Display(Name = "TopicUrl")]
        public string? TopicUrl { get; set; }


        [Required, Display(Name = "UserID")]
         public int UserID { get; set; }

      
        public String? UserName { get; set; }


       
        public int TopicView { get; set; }


        
        public string? Description { get; set; }


        [Required, Display(Name = "MetaTitle")]
        public string? MetaTitle { get; set; }


        
        public string? MetaKeywords { get; set; }


        
        public string? MetaDescription { get; set; }


      
        public string? MetaAuthor { get; set; }


        public string? MetaOgTitle { get; set; }


     
        public string? MetaOgImage { get; set; }


       
        public string? MetaOgDescription { get; set; }


        public string? MetaOgUrl { get; set; }


       
        public string? MetaOgType { get; set; }

        public IFormFile? File2 { get; set; }


        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }

        public class MST_TopicComboboxModel
        {
            public int TopicID { get; set; }
            public string? TopicName { get; set; }
        }
    }
}
