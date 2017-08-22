using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;
namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface IProgramsManager
    {
        GetProgramResponse GetProgramsById(IdRequest request);
        GetProgramsResponse GetPrograms();
        GetCourseProgramNamesResponse GetProgramCourses(GetCourseProgramNamesRequest request);
    }
}
