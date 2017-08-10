using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Api.Models
{
    public class Course
    {
        [Required]
        public int CourseId { get; set; }
        [MaxLength(30)]
        [Required]
        public string CourseName { get; set; }
        [MaxLength(2000)]
        public string CourseDescription { get; set; }
        [Range(1,8)]
        [Required]
        public int Semester { get; set; }
    }
}