using System.Web.Http;
using System.Linq;
using ItLabs.FinkInformator.Api.Responses;
using ItLabs.FinkInformator.Api.Models;
using ItLabs.FinkInformator.Api.Requests;
using System.Web.Http.Cors;
using System;
using NLog;

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
            _logger = LogManager.GetLogger("databaseLogger");
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            
            GetProgramsResponse response = new GetProgramsResponse();
            try
            {
                response.Programs = _schoolContext.Programs.ToList();
            }
            catch (Exception ex)
            {
                
                _logger.Error(ex, "An error has occurred!");

                return BadRequest("An error has occurred");
            }
            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var response = new GetProgramResponse();
            var request = new GetProgramRequest { Id = id };
            try
            {
                response.Program = _schoolContext.Programs.Where(x => x.ProgramId == request.Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error has occured!");

                return BadRequest("An error has occurred");
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("programs/{id}/{semester}")]
        public IHttpActionResult Get(int id, int semester)
        {
           // try { 
                var toReturn = _schoolContext.ProgramsCourses.Where(x => x.ProgramId == id && x.Course.Semester == semester)
                                                                .Select(x => new
                                                                {
                                                                    Course = x.Course,
                                                                    IsMandatory = x.IsMandatory,
                                                                    Prerequisites = _schoolContext.CoursesPrerequisites
                                                                                    .Where(y => y.Course.CourseId == x.Course.CourseId)
                                                                                    .Select(z => z.Prerequisite)
                                                                                    .ToList()
                                                                }).ToList();
            //}catch(Exception ex)
            //{
            //    return BadRequest("An error has occurred");
            //}

            return Ok(toReturn);
           
            
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