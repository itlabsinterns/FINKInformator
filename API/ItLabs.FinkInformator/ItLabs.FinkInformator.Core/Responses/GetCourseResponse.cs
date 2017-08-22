using ItLabs.FinkInformator.Core.Models;

namespace ItLabs.FinkInformator.Core.Responses
{
    public class GetCourseResponse: ResponseBase
    {
        public Course Course { get; set; }
    }
}