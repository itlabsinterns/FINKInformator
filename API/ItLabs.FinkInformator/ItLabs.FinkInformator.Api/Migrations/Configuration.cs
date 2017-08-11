using ItLabs.FinkInformator.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ItLabs.FinkInformator.Api.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolContext context)
        {
            //Try this
            context.Programs.RemoveRange(context.Programs);

            context.Programs.AddRange(FillPrograms(context));


            //context.Programs.AddOrUpdate (new Program() { ProgramName = "KNI" });
            //context.Programs.Add(new Program() { ProgramName = "PET" });
            //context.Programs.Add(new Program() { ProgramName = "IKI" });
            //context.Programs.Add(new Program() { ProgramName = "MT" });

            context.Courses.Add(new Course() { CourseName = "Калкулус 1", Semester = 1 });
            context.Courses.Add(new Course() { CourseName = "Дискретна Математика 1", Semester = 1 });
            context.Courses.Add(new Course() { CourseName = "Структурно Програмирње", Semester = 1 });
            context.Courses.Add(new Course() { CourseName = "Вовед во Информатика", Semester = 1 });
            context.Courses.Add(new Course() { CourseName = "Професионални Вештини", Semester = 1 });
            context.Courses.Add(new Course() { CourseName = "Дискретна Математика 2", Semester = 2 });
            context.Courses.Add(new Course() { CourseName = "Калкулус 2", Semester = 2 });
            context.Courses.Add(new Course() { CourseName = "Објектно-Ориентирано Програмирање", Semester = 2 });
            context.Courses.Add(new Course() { CourseName = "Архитектура и Организација на Компјутери", Semester = 2 });
            context.Courses.Add(new Course() { CourseName = "Дискретна Математика 2", Semester = 2 });
            
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 1, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 2, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 3, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 4, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 5, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 6, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 7, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 8, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 1, CourseId = 9, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 1, IsMandatory = false });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 2, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 3, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 4, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 5, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 6, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 7, IsMandatory = false });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 8, IsMandatory = true });
            context.ProgramsCourses.Add(new ProgramsCourses() { ProgramId = 2, CourseId = 9, IsMandatory = true });
        }
        private List<Program> FillPrograms(SchoolContext context)
        {
            var programs = new List<Program>();

            foreach (var item in Enum.GetValues(typeof(Enums.Program)))
            {
                var programName = item.ToString();

                programs.Add(new Program
                {
                    ProgramName = programName
                });

            }

            return new List<Program>();
        }
        //private void FillCourses(SchoolContext context, string programName)
        //{
        //    var program = context.Programs.SingleOrDefault(x => x.ProgramName == programName);

        //    if (program == null)
        //        return;

        //    var courses = context.ProgramsCourses
        //           .Include(x => x.)
        //           .Where(x => x.Program.ProgramId == program.ProgramId)
        //           .Select(x => new Course
        //           {
                       
        //           })
        //           .ToList();
        //}

    }
}
