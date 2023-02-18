using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.PRO_Program.Models
{
    public class PRO_ProgramSolutionModel
    {

        // ModelName: PRO_ProgramModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public string? F_ProgramID { get; set; }

        public string? F_Defination { get; set; }



        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "ProgramID")]
        public int ProgramID { get; set; }

        [Required, Display(Name = "LevelID")]
        public int LevelID { get; set; }

        [Required, Display(Name = "ProgramNumber")]
        public string? ProgramNumber { get; set; }


        [Required, Display(Name = "Defination")]
        public string? Defination { get; set; }


        [Required, Display(Name = "ProgramDescription")]
        public string? ProgramDesecription { get; set; }


        [Required, Display(Name = "Algoritham")]
        public string? Algoritham { get; set; }


        [Required, Display(Name = "ProgramUrl")]
        public string? ProgramUrl { get; set; }


        [Required, Display(Name = "Sequence")]
        public decimal Sequence { get; set; }


        [Required, Display(Name = "User")]
        public int UserID { get; set; }

        [Required, Display(Name = "UserName")]
        public string? UserName { get; set; }


        [Required, Display(Name = "View")]
        public int ProgramView { get; set; }


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
