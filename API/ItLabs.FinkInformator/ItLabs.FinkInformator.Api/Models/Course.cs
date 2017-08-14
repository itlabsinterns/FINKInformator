using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Api.Models
{
    public class Course
    {
        [Required]
        public int CourseId { get; set; }

        [MaxLength(100)]
        [Required]
        public string CourseName { get; set; }

        [MaxLength(5000)]
        public string CourseDescription { get; set; }

        [Range(1,8)]
        [Required]
        public int Semester { get; set; }

        public IEnumerable<ProgramsCourses> ProgramsCourses { get; set; }


    }
}