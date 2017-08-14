using ItLabs.FinkInformator.Api.Models;
using ItLabs.FinkInformator.Api.Responses;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;

namespace ItLabs.FinkInformator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController: ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {

            SchoolContext context = new SchoolContext();
            CoursesResponse response = new CoursesResponse();
            response.Courses = (from c in context.Courses
                                 select c).ToList<Course>();

            if (response.Courses != null)
            {
                return Ok(response.Courses);
            }
            return BadRequest();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {

            SchoolContext context = new SchoolContext();
            var result = from c in context.Courses
                         where c.CourseId == id
                         select c;

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}