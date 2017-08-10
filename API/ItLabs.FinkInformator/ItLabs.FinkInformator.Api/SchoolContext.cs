//using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ItLabs.FinkInformator.Api.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext():base("name=FinkInformatorConnectionString")
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramsCourses> ProgramsCourses { get; set; }
        public DbSet<CoursesPrerequisites> CoursesPrerequisites { get; set; }
    }
}