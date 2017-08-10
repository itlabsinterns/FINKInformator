namespace ItLabs.FinkInformator.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ItLabs.FinkInformator.Api.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ItLabs.FinkInformator.Api.Models.SchoolContext context)
        {

            context.Programs.Add(new Models.Program() { ProgramName = "KNI" });
            context.Programs.Add(new Models.Program() { ProgramName = "PET" });
            context.Programs.Add(new Models.Program() { ProgramName = "IKI" });
            context.Programs.Add(new Models.Program() { ProgramName = "MT" });
            //context.Courses.Add(new Models.Course() { CourseName = "" });
            context.Courses.Add(new Models.Course() { CourseName = "Калкулус 1", Semester = 1 });
            context.Courses.Add(new Models.Course() { CourseName = "Дискретна Математика 1", Semester = 1 });
            context.Courses.Add(new Models.Course() { CourseName = "Структурно Програмирње", Semester = 1 });
            context.Courses.Add(new Models.Course() { CourseName = "Вовед во Информатика", Semester = 1 });
            context.Courses.Add(new Models.Course() { CourseName = "Професионални Вештини", Semester = 1 });
            context.Courses.Add(new Models.Course() { CourseName = "Дискретна Математика 2", Semester = 2 });
            context.Courses.Add(new Models.Course() { CourseName = "Калкулус 2", Semester = 2 });
            context.Courses.Add(new Models.Course() { CourseName = "Објектно-Ориентирано Програмирање", Semester = 2 });
            context.Courses.Add(new Models.Course() { CourseName = "Архитектура и Организација на Компјутери", Semester = 2 });
            context.Courses.Add(new Models.Course() { CourseName = "Дискретна Математика 2", Semester = 2 });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 1,IsMandatory=true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 2, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 3, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 4, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 5, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 6, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 7, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 8, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 1, CourseId = 9, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 1, IsMandatory = false });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 2, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 3, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 4, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 5, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 6, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 7, IsMandatory = false });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 8, IsMandatory = true });
            context.ProgramsCourses.Add(new Models.ProgramsCourses() { ProgramId = 2, CourseId = 9, IsMandatory = true });




        }
        private static void FillPrograms(Models.SchoolContext context)
        {

        }
        private static void FillCourses(Models.SchoolContext context)
        {
     
        }

    }
}
