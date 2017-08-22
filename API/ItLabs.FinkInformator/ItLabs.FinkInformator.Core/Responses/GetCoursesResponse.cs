using ItLabs.FinkInformator.Core.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Core.Responses
{
    public class GetCoursesResponse: ResponseBase
    {
        public GetCoursesResponse()
        {
            Courses = new List<Course>();
        }

        public List<Course> Courses { get; set; }
    }
}