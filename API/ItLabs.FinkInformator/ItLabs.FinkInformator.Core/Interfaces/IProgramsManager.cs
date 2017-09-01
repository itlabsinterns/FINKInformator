using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface IProgramsManager
    {
        ProgramResponse GetProgramsById(IdRequest request);
        GetProgramsResponse GetPrograms();
        GetProgramCoursesResponse GetProgramCourses(GetProgramCoursesRequest request);
        ProgramResponse CreateProgram(CreateProgramRequest request);
        ProgramResponse UpdateProgram(UpdateProgramRequest request);
        ResponseBase DeleteProgram(IdRequest request);
    }
}
