using ItLabs.FinkInformator.Api.Models;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class GetCourseResponse: ResponseBase
    {
        public Course Course { get; set; }
    }
}