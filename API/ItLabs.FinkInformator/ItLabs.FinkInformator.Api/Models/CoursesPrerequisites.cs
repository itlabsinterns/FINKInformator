using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Api.Models
{
    public class CoursesPrerequisites
    {
        [Required]
        public int CoursesPrerequisitesId { get; set; }
        public Course Course { get; set; }

        public Course Prerequisite { get; set; }

    }   
}