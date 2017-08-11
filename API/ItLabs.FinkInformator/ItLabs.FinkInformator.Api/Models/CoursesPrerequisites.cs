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