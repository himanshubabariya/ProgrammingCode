using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace ProgrammingCode.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {

        // ModelName: SEC_UserModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        public string? F_UserID { get; set; }

        public string? F_UserName { get; set; }



        /*******************************************************************
         *	ADDEDIT FORM
         *******************************************************************/
        [Required, Display(Name = "UserID")]
        public int UserID { get; set; }

        

        [Required, Display(Name = "UserName")]
        public string? UserName { get; set; }


        [Required, Display(Name = "Password")]
        public string? Password { get; set; }


        [Required, Display(Name = "Email")]
        public string? Email { get; set; }

        [Required, Display(Name = "MobileNo")]
        public string? MobileNo { get; set; }


        [Required, Display(Name = "DisplayName")]
        public string? DisplayName { get; set; }
        [Required, Display(Name = "CreatedUser")]
        public string? CreatedUser { get; set; }
        
        public string? Description { get; set; }

        [Required, Display(Name = "CreatedUserID")]
        public int CreatedUserID { get; set; }

        [Required, Display(Name = "IsActive")]
        public int IsActive { get; set; }

  
        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }

        public class SEC_UserComboboxModel
        {
            public int UserID { get; set; }
            public string? UserName { get; set; }
        }
    }
}
