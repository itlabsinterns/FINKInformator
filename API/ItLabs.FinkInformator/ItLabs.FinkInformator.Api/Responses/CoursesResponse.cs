using ItLabs.FinkInformator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class CoursesResponse: ResponseBase
    {
        //Property containing all Programs
        public List<Course> Courses { get; set; }

        //Class constructor
        public CoursesResponse():base()
        {
            Courses = new List<Course>();
        }
    }
}