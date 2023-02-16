using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.PRO_ProgramTopic.Models
{
    public class PRO_ProgramTopic
    {
        // ModelName: MST_ProgrammingLangaugeModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public string? F_ProgramTopicID { get; set; }

        public string? F_LevelName { get; set; }



        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "LevelID")]
        public int LevelID { get; set; }


        [Required, Display(Name = "LevelName")]
        public string? LevelName { get; set; }


        [Required, Display(Name = "LevelDescription")]
        public string? LevelDescription { get; set; }


        [Required, Display(Name = "Sequence")]
        public decimal Sequence { get; set; }

        [Required, Display(Name = "Description")]
        public string? Description { get; set; }

        [Required, Display(Name = "User")]
        public int UserID { get; set; }

        [Required, Display(Name = "UserName")]
        public String? UserName { get; set; }


        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }
    }
}
