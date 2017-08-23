using ItLabs.FinkInformator.Core.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Core.Responses
{
    public class GetCoursePrerequisitesResponse : ResponseBase
    {
        public GetCoursePrerequisitesResponse()
        {
            Prerequisites = new List<Course>();
        }
        public List<Course> Prerequisites { get; set; }
    }
}