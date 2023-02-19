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


        [Required, Display(Name = "ProgrammingLangaugeShortDescription")]
        public string? ProgrammingLangaugeShortDescription { get; set; }


        [Required, Display(Name = "ProgrammingLangaugeDetailedDescription")]
        public string? ProgrammingLangaugeDetailedDescription { get; set; }


        [Required, Display(Name = "ProgrammingLangaugeLogo")]
        public string? ProgrammingLangaugeLogo { get; set; }


        [Required, Display(Name = "Sequence")]
        public decimal Sequence { get; set; }


        [Required, Display(Name = "User")]
        public int UserID { get; set; }

        [Required, Display(Name = "UserName")]
        public String? UserName { get; set; }


        [Required, Display(Name = "View")]
        public int ProgrammingLangaugeView { get; set; }


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


        public IFormFile File { get; set; }


        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }

        public class PRO_ProgrammingLangaugeComboBoxModel
        {
            public int ProgrammingLangaugeID { get; set; }
            public string? ProgrammingLangaugeName { get; set; }
        }
    }
}
