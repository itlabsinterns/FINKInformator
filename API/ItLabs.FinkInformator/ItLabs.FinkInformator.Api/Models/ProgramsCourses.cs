using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ItLabs.FinkInformator.Api.Models
{
    public class ProgramsCourses
    {
        [Required]
        
        public int ProgramsCoursesId { get; set; }
        public Program Program { get; set; }
        [Required]
        public int ProgramId { get; set; }
        public Course Course { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public bool IsMandatory { get; set; }   

    }
}