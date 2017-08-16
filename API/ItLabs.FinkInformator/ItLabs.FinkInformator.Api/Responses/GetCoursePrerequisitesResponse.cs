using ItLabs.FinkInformator.Api.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class GetCoursePrerequisitesResponse:ResponseBase
    {
        public GetCoursePrerequisitesResponse()
        {
            Prerequisites = new List<Course>();
        }

        public List<Course> Prerequisites { get; set; }
    }
}