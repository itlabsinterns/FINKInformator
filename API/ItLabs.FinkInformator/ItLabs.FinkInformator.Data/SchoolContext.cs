using System.Data.Entity;
using ItLabs.FinkInformator.Core.Models;

namespace ItLabs.FinkInformator.Data.Models
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