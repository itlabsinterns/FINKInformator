using ItLabs.FinkInformator.Core.Models;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Data.Models;
using System.Linq;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Data
{
    public class ProgramsRepository:IProgramsRepository
    {
        private SchoolContext _schoolContext;
        public ProgramsRepository()
        {
            _schoolContext = new SchoolContext();
        }
        public IQueryable<Program> getPrograms()
        {
            return _schoolContext.Programs;
        }
        public IQueryable<ProgramsCoursesCustom> GetProgramCourses(GetProgramCoursesRequest request)
        {
            return _schoolContext.ProgramsCourses.Where(x => x.ProgramId == request.ProgramId && x.Course.Semester == request.Semester)
                                                                .Select(x => new ProgramsCoursesCustom
                                                                {
                                                                    Course = x.Course,
                                                                    IsMandatory = x.IsMandatory,
                                                                    Prerequisites = _schoolContext.CoursesPrerequisites
                                                                                    .Where(y => y.Course.CourseId == x.Course.CourseId)
                                                                                    .Select(z => z.Prerequisite).ToList()
                                                                });

        }
    }
}
