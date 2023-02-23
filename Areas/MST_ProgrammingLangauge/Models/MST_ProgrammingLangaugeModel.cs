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
        [Required, Display(Name = "ProgrammingLangauge")]
        public int ProgrammingLangaugeID { get; set; }


        [Required, Display(Name = "ProgrammingLangaugeName")]
        public string? ProgrammingLangaugeName { get; set; }


        [Display(Name = "ProgrammingLangaugeShortDescription")]
        public string? ProgrammingLangaugeShortDescription { get; set; }


        [Display(Name = "ProgrammingLangaugeDetailedDescription")]
        public string? ProgrammingLangaugeDetailedDescription { get; set; }


        [Display(Name = "ProgrammingLangaugeLogo")]
        public string? ProgrammingLangaugeLogo { get; set; }


        [ Display(Name = "Sequence")]
        public decimal Sequence { get; set; }


        [Display(Name = "User")]
        public int UserID { get; set; }

        [ Display(Name = "UserName")]
        public String? UserName { get; set; }


        [ Display(Name = "View")]
        public int ProgrammingLangaugeView { get; set; }


        [ Display(Name = "Description")]
        public string? Description { get; set; }


        [ Display(Name = "MetaTitle")]
        public string? MetaTitle { get; set; }


        [ Display(Name = "MetaKeywords")]
        public string? MetaKeywords { get; set; }


        [ Display(Name = "MetaDescription")]
        public string? MetaDescription { get; set; }


        [ Display(Name = "MetaAuthor")]
        public string? MetaAuthor { get; set; }


        [ Display(Name = "MetaOgTitle")]
        public string? MetaOgTitle { get; set; }


        [ Display(Name = "MetaOgImage")]
        public string? MetaOgImage { get; set; }


        [Display(Name = "MetaOgDescription")]
        public string? MetaOgDescription { get; set; }


        [ Display(Name = "MetaOgUrl")]
        public string? MetaOgUrl { get; set; }


        [ Display(Name = "MetaOgType")]
        public string? MetaOgType { get; set; }


        public IFormFile File { get; set; }
        public IFormFile File2 { get; set; }

        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }

        public class PRO_ProgrammingLangaugeComboBoxModel
        {
            public int ProgrammingLangaugeID { get; set; }
            public string? ProgrammingLangaugeName { get; set; }
        }
    }
}
