using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.PRO_ProgramSolution.Models
{
    public class PRO_ProgramSolutionModel
    {

        // ModelName: PRO_ProgramSolutionModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public int F_ProgramSolutionID { get; set; }

        public int F_ProgramID { get; set; }

        public string? F_Defination { get; set; }
        public string? F_UserName { get; set; }



        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "ProgramSolutionID")]
        public int ProgramSolutionID { get; set; }

        [Required, Display(Name = "ProgramSolution")]
        public string? ProgramSolution { get; set; }

        [Required, Display(Name = "ProgramID")]
        public int ProgramID { get; set; }

        [Required, Display(Name = "ProgrammingLangaugeID")]
        public int ProgrammingLangaugeID { get; set; }

        [Required, Display(Name = "User")]
        public int UserID { get; set; }

        [Required, Display(Name = "Description")]
        public string? Description { get; set; }
     
        [Required, Display(Name = "Defination")]
        public string? Defination { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
