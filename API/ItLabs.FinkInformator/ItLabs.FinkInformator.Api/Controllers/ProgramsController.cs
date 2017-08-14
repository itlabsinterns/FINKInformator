using System.Web.Http;
using System.Linq;
using ItLabs.FinkInformator.Api.Responses;
using ItLabs.FinkInformator.Api.Models;
using ItLabs.FinkInformator.Api.Requests;

namespace ItLabs.FinkInformator.Api.Controllers
{
    public class ProgramsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {

            SchoolContext context = new SchoolContext();
            ProgramsResponse response = new ProgramsResponse();
            response.Programs = (from p in context.Programs
                                 select p).ToList<Program>();

            if (response.Programs != null)
            {
                return Ok(response.Programs);
            }
            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {

            SchoolContext context = new SchoolContext();
            var result = from p in context.Programs
                         where p.ProgramId == id
                         select p;

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult Get(int id, int semester)
        {

            SchoolContext context = new SchoolContext();
            var result = from p in context.ProgramsCourses
                         where p.ProgramId == id && p.Course.Semester == semester
                         select p.Course;

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //[HttpGet]
        //public IHttpActionResult Get([FromUri]GetProgramCoursesRequest request)
        //{

        //    SchoolContext context = new SchoolContext();
        //    var result = from p in context.ProgramsCourses
        //                 where p.ProgramId == request.ProgramId && p.Course.Semester == request.Semester
        //                 select p.Course;

        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}

    }
}