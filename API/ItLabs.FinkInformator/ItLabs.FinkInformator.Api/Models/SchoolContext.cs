using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ItLabs.FinkInformator.Api.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext():base("FINKInformator")
        {

        }
        public DbSet<Course> Courses { get; set; }
    }
}