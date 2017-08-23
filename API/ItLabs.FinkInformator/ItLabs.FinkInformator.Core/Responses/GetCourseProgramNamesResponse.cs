using ItLabs.FinkInformator.Core.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Core.Responses
{
    public class GetCourseProgramNamesResponse : ResponseBase
    {
        public GetCourseProgramNamesResponse()
        {
            CourseProgramNames = new List<CourseProgramName>();
        }
        public List<CourseProgramName> CourseProgramNames { get; set; }
    }
}
