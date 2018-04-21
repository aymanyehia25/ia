using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Field is Required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Level Field is Required")]
        public int level { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "SSN Field is Required")]
        public string SSN { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "GPA Field is Required")]
        public float GPA { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone Field is Required")]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Skills Field is Required")]
        public string Skills { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Transcript Field is Required")]
        public string Transcript { get; set; }
        public int teamleaderid { get; set; }
        public Project projectid { get; set; }






    }
}