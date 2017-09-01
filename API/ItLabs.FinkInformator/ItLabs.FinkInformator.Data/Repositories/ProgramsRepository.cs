using ItLabs.FinkInformator.Core.Models;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Data.Models;
using System.Linq;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Data
{
    public class ProgramsRepository : IProgramsRepository
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
        public IQueryable<ProgramCoursesDto> GetProgramCourses(GetProgramCoursesRequest request)
        {
            return _schoolContext.ProgramsCourses.Where(x => x.ProgramId == request.ProgramId && x.Course.Semester == request.Semester)
                                                                .Select(x => new ProgramCoursesDto
                                                                {
                                                                    Course = x.Course,
                                                                    IsMandatory = x.IsMandatory,
                                                                    Prerequisites = _schoolContext.CoursesPrerequisites
                                                                                    .Where(y => y.Course.CourseId == x.Course.CourseId)
                                                                                    .Select(z => z.Prerequisite).ToList()
                                                                });

        }

        public void AddProgram(Program program)
        {
            _schoolContext.Programs.Add(program);
            _schoolContext.SaveChanges();
        }

        public void UpdateProgram(Program program)
        {
            _schoolContext.Entry(program).State = System.Data.Entity.EntityState.Modified;
            _schoolContext.SaveChanges();
        }

        public void RemoveProgram(Program program)
        {
            _schoolContext.ProgramsCourses.RemoveRange(_schoolContext.ProgramsCourses
                                           .Where(x => x.Program.ProgramId == program.ProgramId).ToList());
            _schoolContext.Programs.Remove(program);
            _schoolContext.SaveChanges();
        }
    }
}
