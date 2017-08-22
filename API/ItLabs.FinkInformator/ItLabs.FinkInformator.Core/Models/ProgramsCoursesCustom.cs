using System.Collections.Generic;

namespace ItLabs.FinkInformator.Core.Models
{
    public class ProgramsCoursesCustom
    {
        public Course Course { get; set; }
        public bool IsMandatory { get; set; }
        public List<Course> Prerequisites { get; set; }
    }
}
