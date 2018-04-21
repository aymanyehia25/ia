using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class Professor
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Department Field is Required")]
        public string Department { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Interest Field is Required")]
        public string Interest { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "History Field is Required")]
        public string History { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "photo Field is Required")]
        public string photo { get; set; }
        public int Num_teams { get; set; } //dh hyb2a el user id mo2kten 
       
      


    }
}