using ItLabs.FinkInformator.Data.Models;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Data.Repositories
{
    public class CoursesRepository : ICoursesRepository
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

        public List<CourseProgramName> GetProgramCourseNames(string courseName)
        {
            return _schoolContext.ProgramsCourses.Where(x => x.Course.CourseName.Contains(courseName))
                .Select(x => new CourseProgramName
                {
                    CourseName = x.Course.CourseName,
                    ProgramName = x.Program.ProgramName,
                    CourseId = x.Course.CourseId
                }).ToList();
        }

        public Course CreateCourse(Course course, List<ProgramsCourses> programsCourses, List<int> coursePrerequisiteIds)
        {
            var savedCourse = _schoolContext.Courses.Add(course);
            var Prerequisites = _schoolContext.Courses.Where(x => coursePrerequisiteIds.Contains(x.CourseId)).ToList();
            var coursePrerequisites = new List<CoursesPrerequisites>();
            foreach (var entity in Prerequisites)
            {
                coursePrerequisites.Add(new CoursesPrerequisites()
                {
                    Course = savedCourse,
                    Prerequisite = entity
                });

            }
            _schoolContext.CoursesPrerequisites.AddRange(coursePrerequisites);
            _schoolContext.ProgramsCourses.AddRange(programsCourses);
            _schoolContext.SaveChanges();

            return savedCourse;
        }

        public void UpdateCourse(Course courseToUpdate, List<ProgramsCourses> programsCourses, List<int> coursePrerequisiteIds)
        {
            _schoolContext.CoursesPrerequisites.RemoveRange(_schoolContext.CoursesPrerequisites
                                               .Where(x => x.Course.CourseId == courseToUpdate.CourseId).ToList());

            var newPrerequisites = _schoolContext.Courses
                                    .Where(x => coursePrerequisiteIds.Contains(x.CourseId)).ToList();

            var newCoursePrerequisites = new List<CoursesPrerequisites>();
            foreach (var entity in newPrerequisites)
            {
                newCoursePrerequisites.Add(new CoursesPrerequisites()
                {
                    Course = courseToUpdate,
                    Prerequisite = entity
                });
            }
            _schoolContext.CoursesPrerequisites.AddRange(newCoursePrerequisites);

            _schoolContext.ProgramsCourses.RemoveRange(_schoolContext.ProgramsCourses
                                          .Where(x => x.CourseId == courseToUpdate.CourseId).ToList());

            _schoolContext.ProgramsCourses.AddRange(programsCourses);
            _schoolContext.Entry(courseToUpdate).State = System.Data.Entity.EntityState.Modified;
            _schoolContext.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            _schoolContext.CoursesPrerequisites.RemoveRange(_schoolContext.CoursesPrerequisites.Where(x => x.Course.CourseId == course.CourseId).ToList());
            _schoolContext.ProgramsCourses.RemoveRange(_schoolContext.ProgramsCourses.Where(x => x.Course.CourseId == course.CourseId).ToList());
            _schoolContext.Courses.Remove(course);
            _schoolContext.SaveChanges();
        }
    }
}
