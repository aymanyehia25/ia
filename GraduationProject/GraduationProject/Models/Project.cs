using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GraduationProject.Models
{
    public class Project
    {


        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "project Title Field is Required")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "project description  Field is Required")]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "used tools for project Field is Required")]
        public string UsedTools { get; set; }

    }
}