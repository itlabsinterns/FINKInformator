using ItLabs.FinkInformator.Api.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Api.Responses
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