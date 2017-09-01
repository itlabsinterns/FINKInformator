using ItLabs.FinkInformator.Core.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Core.Requests
{
    /*
     {
	"CourseName" : "Nov Kurs",
	"CourseDescription" : "Description works",
	"Semester" : 5,
	"Prerequisites" : [160,161,162,163,164],
	"Programs" : [{"ProgramId" : 25, "IsMandatory": "true"}]
    }
         */
    public class PostCourseRequest
    {
        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public int Semester { get; set; }

        public List<int> Prerequisites { get; set; } 

        public List<ProgramsIsMandatoryHelper> Programs { get; set; }
    }
}
