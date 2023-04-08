using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.MST_ProgrammingCode.Models
{
    public class MST_ProgrammingLangaugeModel

    {
        // ModelName: MST_ProgrammingLangaugeModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public string? L_ProgrammingLangaugeID { get; set; }

        public string? L_ProgrammingLangaugeName { get; set; }



        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "ProgrammingLangaugeID")]
        public int ProgrammingLangaugeID { get; set; }


        [Required, Display(Name = "ProgrammingLangaugeName")]
        public string? ProgrammingLangaugeName { get; set; }


        public string? ProgrammingLangaugeShortDescription { get; set; }


        public string? ProgrammingLangaugeDetailedDescription { get; set; }


        public string? ProgrammingLangaugeLogo { get; set; }
        [Required, Display(Name = "LanguageUrl")]

        public string? LanguageUrl { get; set; }

        public decimal? Sequence { get; set; }


        public int UserID { get; set; }

        public string? UserName { get; set; }


        public int ProgrammingLangaugeView { get; set; }


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


        public IFormFile? File { get; set; }
        public IFormFile? File2 { get; set; }

        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }

        public class PRO_ProgrammingLangaugeComboBoxModel
        {
            public int ProgrammingLangaugeID { get; set; }
            public string? ProgrammingLangaugeName { get; set; }
        }
    }
}
