using ItLabs.FinkInformator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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