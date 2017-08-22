
using System.ComponentModel.DataAnnotations;

namespace ItLabs.FinkInformator.Core.Models
{
    public class CoursesPrerequisites
    {
        [Required]
        public int CoursesPrerequisitesId { get; set; }

        public Course Course { get; set; }

        public Course Prerequisite { get; set; }

    }   
}