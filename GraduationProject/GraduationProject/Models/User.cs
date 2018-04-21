using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class User
    {

        public int ID { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Field is Required")]
        public string Name { get; set; }




        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Field is Required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "You Must Enter at leaset 6 Characters")]
        public string Password { get; set; }





        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The two Passowords do not match")]
        public string ConfirmPassword { get; set; }




        public string Role { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Field is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        public bool IsEmail { get; set; }
        public string Activationcode { get; set; }
        public bool Rememberme { get; set; }

    }
}