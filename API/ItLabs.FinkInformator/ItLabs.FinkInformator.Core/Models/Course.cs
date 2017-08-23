using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Core.Models
{
    /// <summary>
    /// Course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// ID of the course
        /// </summary>
        [Required]
        public int CourseId { get; set; }

        /// <summary>
        /// Name of the course
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string CourseName { get; set; }

        /// <summary>
        /// Topics being covered by the course
        /// </summary>
        [MaxLength(5000)]
        public string CourseDescription { get; set; }

        /// <summary>
        /// Number of semester in which the course is offered
        /// </summary>
        [Range(1, 8)]
        [Required]
        public int Semester { get; set; }

        public IEnumerable<ProgramsCourses> ProgramsCourses { get; set; }


    }
}