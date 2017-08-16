using System.Web.Http;
using System.Linq;
using ItLabs.FinkInformator.Api.Responses;
using ItLabs.FinkInformator.Api.Models;
using ItLabs.FinkInformator.Api.Requests;
using System.Web.Http.Cors;
using System;
using NLog;
using System.ComponentModel;

namespace ItLabs.FinkInformator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProgramsController : ApiController
    {
        private SchoolContext _schoolContext;
        private Logger _logger;

        public ProgramsController()
        {
            _schoolContext = new SchoolContext();
            _logger = LogManager.GetLogger("fileLog");
        }

        /// <summary>
        /// Get all programs
        /// </summary>
        /// <returns></returns>
        [Description("Get all programs")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var response = new GetProgramsResponse();

            try
            {
                response.Programs = _schoolContext.Programs.ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest("An error has occurred");
            }

            return Ok(response);
        }

        /// <summary>
        /// Get a particular program
        /// </summary>
        /// <param name="id">The ID of the requested program</param>
        /// <returns></returns>
        [Description("Get Program by Id")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var response = new GetProgramResponse();
            var request = new IdRequest { Id = id };
            try
            {
                response.Program = _schoolContext.Programs.Where(x => x.ProgramId == request.Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest("An error has occurred");
            }

            return Ok(response);
        }

        /// <summary>
        /// Get all courses for a particular program and semester as well as additional information if the courses are mandatory and their prerequisites
        /// </summary>
        /// <param name="id">The ID of the program</param>
        /// <param name="semester">The number of the semester</param>
        /// <returns></returns>
        [Description("Get Courses based on Semester and Program")]
        [HttpGet]
        [Route("programs/{id}/{semester}")]
        public IHttpActionResult GetProgramCourses(int id, int semester)
        {
            //TODO covert this to response class

            var request = new GetProgramCoursesRequest { ProgramId = id, Semester = semester };
            dynamic programCourses;

            try
            {
                programCourses = _schoolContext.ProgramsCourses.Where(x => x.ProgramId == request.ProgramId && x.Course.Semester == request.Semester)
                                                                    .Select(x => new
                                                                    {
                                                                        Course = x.Course,
                                                                        IsMandatory = x.IsMandatory,
                                                                        Prerequisites = _schoolContext.CoursesPrerequisites
                                                                                        .Where(y => y.Course.CourseId == x.Course.CourseId)
                                                                                        .Select(z => z.Prerequisite)
                                                                                        .ToList()
                                                                    }).ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return BadRequest("An error has occurred");
            }

            return Ok(programCourses);
        }
    }
}