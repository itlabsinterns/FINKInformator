using ItLabs.FinkInformator.Api.Models;
using ItLabs.FinkInformator.Api.Responses;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;
using System;
using ItLabs.FinkInformator.Api.Requests;
using NLog;
using System.ComponentModel;
using System.Web.Http.Description;

namespace ItLabs.FinkInformator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController : ApiController
    {
        private SchoolContext _schoolContext;
        private Logger _logger;

        public CoursesController()
        {
            _schoolContext = new SchoolContext();
            _logger = LogManager.GetLogger("fileLog");
        }

        /// <summary>
        /// Get all courses
        /// </summary>
        /// <returns></returns>
        [Description("Get all Courses")]
        [ResponseType(typeof(GetCoursesResponse))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var response = new GetCoursesResponse();
            try
            {
                response.Courses = _schoolContext.Courses.ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest("An error has occurred");
            }

            return Ok(response);
        }

        /// <summary>
        /// Get a particular course by ID
        /// </summary>
        /// <param name="id">The ID of the requested course</param>
        /// <returns></returns>
        [Description("Get Course by Id")]
        [ResponseType(typeof(GetCourseResponse))]
        [HttpGet]
        public IHttpActionResult GetCourse(int id)
        {
            var response = new GetCourseResponse();
            var request = new IdRequest { Id = id };

            if (request.Id <= 0)
            {
                response.IsSuccessful = false;
                response.Errors.Add("Invalid parameter: id");

                _logger.Error(response);


                return Ok(response);
            }
            try
            {
                response.Course = _schoolContext.Courses.Where(x => x.CourseId == request.Id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                return BadRequest("An error has occurred");
            }

            return Ok(response);
        }

        /// <summary>
        /// Get prerequisite courses for a particular course
        /// </summary>
        /// <param name="id">The ID of the course whose prerequisites are about to be returned</param>
        /// <returns></returns>
        [Description("Get Courses Prerequisites")]
        [ResponseType(typeof(GetCoursePrerequisitesResponse))]
        [HttpGet]
        [Route("courses/{id}/prerequisites")]
        public IHttpActionResult GetCoursePrerequisites(int id)
        {
            var response = new GetCoursePrerequisitesResponse();
            try
            {
                response.Prerequisites = _schoolContext.CoursesPrerequisites
                                                       .Where(x => x.Course.CourseId == id)
                                                       .Select(x => x.Prerequisite).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                return BadRequest("An error has occurred");
            }

            return Ok(response);
        }

        /// <summary>
        /// Get filtered courses by course name
        /// </summary>
        /// <param name="value">Typed value used for filtering course names</param>
        /// <returns></returns>
        [Description("Get Filtered Courses By Name")]
        [HttpGet]
        [Route("courses/names/{value}")]
        public IHttpActionResult GetCourseProgramNames(string value)
        {
            dynamic coursesNames;
            try
            {
                coursesNames = _schoolContext.ProgramsCourses.Where(x => x.Course.CourseName.Contains(value)).Select(
                    x => new
                    {
                        Id = x.CourseId,
                        CourseName = x.Course.CourseName,
                        ProgramName = x.Program.ProgramName
                    }).ToList();

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest("An error has occurred!");
            }

            return Ok(coursesNames);
        }
    }
}