using ItLabs.FinkInformator.Data.Models;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ItLabs.FinkInformator.Data.Repositories
{
    public class CoursesRepository:ICoursesRepository
    {
        private SchoolContext _schoolContext;
        public CoursesRepository()
        {
            _schoolContext = new SchoolContext();
        }

        public IQueryable<Course> GetAllCourses()
        {
            return _schoolContext.Courses;
        }

        public Course GetCourseById(int id)
        {
            return _schoolContext.Courses.Where(x => x.CourseId == id).FirstOrDefault();
        }

        public List<Course> GetCoursePrerequisites(int id)
        {
            return _schoolContext.CoursesPrerequisites.Where(x => x.Course.CourseId == id)
                                                       .Select(x => x.Prerequisite).ToList();
        }

        public List<CourseProgramName> getProgramCourseNames(string CourseName)
        {
            return _schoolContext.ProgramsCourses.Where(x => x.Course.CourseName.Contains(CourseName))
                .Select(x => new CourseProgramName
                {
                    CourseName = x.Course.CourseName,
                    ProgramName = x.Program.ProgramName,
                    CourseId = x.Course.CourseId
                }).ToList();
        }
    }
}
