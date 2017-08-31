
using ItLabs.FinkInformator.Core.Models;
using System.Linq;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface IProgramsRepository
    {
        IQueryable<Program> getPrograms();
        IQueryable<ProgramCoursesDto> GetProgramCourses(GetProgramCoursesRequest request);
        void AddProgram(Program program);
    }
}
