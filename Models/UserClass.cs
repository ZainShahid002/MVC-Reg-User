using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Reg_User.Models
{
    public class UserClass
    {
        [Required(ErrorMessage ="Enter username  !")]
        [Display(Name ="Enter name:")]
        [StringLength(maximumLength:7 , MinimumLength =3,ErrorMessage ="username length must be max 7 & min 3")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "please Enter email  !")]
        [Display(Name = "Email Id:")]
        public string Uemail { get; set; }

        [Required(ErrorMessage = "Enter the password  !")]
        [Display(Name = "password:")]
        [DataType(DataType.Password)]
        public string Upwd { get; set; }

        [Required(ErrorMessage = "Enter the password  !")]
        [Display(Name = "Re-password:")]
        [DataType(DataType.Password)]
        [Compare("Upwd")]
        public string Repwd { get; set; }


        [Required(ErrorMessage = "select the gender  !")]
        [Display(Name = "Gender:")]
        public char Gender { get; set; }


        [Required(ErrorMessage = "Upload Profile Image !")]
        [Display(Name = "profile Image:")]
        public string Uimg { get; set; }
    }
}