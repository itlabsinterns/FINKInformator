using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;
using ItLabs.FinkInformator.Core.Models;

namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface IProgramsManager
    {
        GetProgramResponse GetProgramsById(IdRequest request);
        GetProgramsResponse GetPrograms();
        GetProgramCoursesResponse GetProgramCourses(GetProgramCoursesRequest request);
        ResponseBase AddProgram(Program program);
        ResponseBase ModifyProgram(int id, Program program);
    }
}
