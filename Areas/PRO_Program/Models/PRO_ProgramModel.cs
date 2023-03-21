using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProgrammingCode.Areas.PRO_Program.Models
{
    public class PRO_ProgramModel
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


        
        public string? ProgramDesecription { get; set; }



        public string? Algoritham { get; set; }


        [Required, Display(Name = "ProgramUrl")]
        public string? ProgramUrl { get; set; }
        

        
        public decimal? Sequence { get; set; }


  
        public int UserID { get; set; }

       
        public string? UserName { get; set; }


      
        public int ProgramView { get; set; }


     
        public string? Description { get; set; }


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

        /*******************************************************************
        *	combobox
        *******************************************************************/
        public class PRO_ProgramComboboxModel
        {
            public int ProgramID { get; set; }
            public string? Defination { get; set; }
        }

    }
}
