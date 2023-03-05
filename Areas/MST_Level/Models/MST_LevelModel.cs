using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.MST_Level.Models
{
    public class MST_LevelModel
    {
        // ModelName: MST_LevelModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public string? F_LevelID { get; set; }

        public string? F_LevelName { get; set; }

        public string? F_UserName { get; set; }



        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "LevelID")]
        public int LevelID { get; set; }


        [Required, Display(Name = "LevelName")]
        public string? LevelName { get; set; }
    
        public string? LevelDescription { get; set; }

        public decimal Sequence { get; set; }

        public string? Description { get; set; }

        [Required, Display(Name = "User")]
        public int UserID { get; set; }


        public String? UserName { get; set; }


        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }

        /***************************************************/
        /*COMOBOX MODLE*/
        /****************************************************/
        public class MST_LevelComboboxModel
        {
            public int LevelID { get; set; }
            public string? LevelName { get; set; }
        }
    }
}
