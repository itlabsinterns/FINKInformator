using ItLabs.FinkInformator.Core.Responses;
using System.Web.Http;
using System.Web.Http.Cors;
using ItLabs.FinkInformator.Core.Requests;
using NLog;
using System.ComponentModel;
using System.Web.Http.Description;
using ItLabs.FinkInformator.Core.Interfaces;
using System;

namespace ItLabs.FinkInformator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController : ApiController
    {
        private ICoursesManager _manager;
        private Logger _logger;

        public CoursesController(ICoursesManager courseManager)
        {
            _manager = courseManager;
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
            var response = _manager.GetCourses();
            if (!response.IsSuccessful)
                return BadRequest("An error has occurred");
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
            var request = new IdRequest { Id = id };
            var response = _manager.GetCourseById(request);
            if (!response.IsSuccessful)
                return BadRequest("An error has occurred");

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
            IdRequest request = new IdRequest() { Id = id };
            GetCoursePrerequisitesResponse response = _manager.GetCoursePrerequisites(request);
            if (!response.IsSuccessful)
                return BadRequest("An error has occurred");

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

            GetCourseProgramNamesRequest request = new GetCourseProgramNamesRequest { CourseName = value };
            GetCourseProgramNamesResponse response = new GetCourseProgramNamesResponse();
            try
            {
                response = _manager.GetCourseProgramNames(request);

            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest("An error has occurred!");
            }

            return Ok();
        }
    }
}