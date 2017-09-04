
using ItLabs.FinkInformator.Core.Models;
using System.Linq;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface IProgramsRepository
    {
        IQueryable<Program> GetPrograms();
        Program GetProgramById(int id);
        IQueryable<ProgramCoursesDto> GetProgramCourses(GetProgramCoursesRequest request);
        Program CreateProgram(Program program);
        Program UpdateProgram(Program programToModify);
        void RemoveProgram(Program program);
    }
}
