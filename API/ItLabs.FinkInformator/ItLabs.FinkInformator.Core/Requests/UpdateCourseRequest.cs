using ItLabs.FinkInformator.Core.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Core.Requests
{
    public class UpdateCourseRequest
    {
        public int OldCourseId { get; set; }

        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public int Semester { get; set; }

        public List<int> Prerequisites { get; set; }

        public List<ProgramsIsMandatoryDto> Programs { get; set; }
    }
}
