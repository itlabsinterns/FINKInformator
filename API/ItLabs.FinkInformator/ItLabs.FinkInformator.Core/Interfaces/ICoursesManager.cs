using ItLabs.FinkInformator.Core.Requests;
using ItLabs.FinkInformator.Core.Responses;

namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface ICoursesManager
    {
        GetCoursesResponse GetCourses();
        GetCourseResponse GetCourseById(IdRequest request);
        GetCoursePrerequisitesResponse GetCoursePrerequisites(IdRequest request);
        GetCourseProgramNamesResponse GetCourseProgramNames(GetCourseProgramNamesRequest request);
        ResponseBase AddCourse(PostCourseRequest request);
    }
}
