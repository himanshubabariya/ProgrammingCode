using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.PRO_ProgramTestCase.Models
{
    public class PRO_ProgramTestCaseModel
    {
        // ModelName: MST_LevelModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public int? F_ProgramTestCaseID { get; set; }

        public string? F_TastCaseDescription { get; set; }

        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "ProgramTestCaseID")]
        public int ProgramTestCaseID { get; set; }


        [Required, Display(Name = "ProgramID")]
        public int ProgramID { get; set; }

       
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }


        [Required, Display(Name = "TastCaseDescription")]
        public string? TastCaseDescription { get; set; }

        [Required, Display(Name = "IsPositive")]
        public int IsPositive { get; set; }

        [Required, Display(Name = "Sequence")]
        public decimal Sequence { get; set; }

        [Required, Display(Name = "Description")]
        public string? Description { get; set; }

        [Required, Display(Name = "UserID")]
        public int UserID { get; set; }


        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }

        /***************************************************/
        /*COMOBOX MODLE*/
        /****************************************************/
        
    }
}
