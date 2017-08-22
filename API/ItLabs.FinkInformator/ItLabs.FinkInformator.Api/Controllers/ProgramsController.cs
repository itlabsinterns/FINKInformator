using System.Web.Http;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Requests;
using System.Web.Http.Cors;
using NLog;
using System.ComponentModel;
using ItLabs.FinkInformator.Domain.Managers;

namespace ItLabs.FinkInformator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ProgramsController : ApiController
    {
        private IProgramsManager _manager;
        private Logger _logger;
        ///<summary>
        ///Programs Controller Constructor
        /// </summary>
        /// <returns></returns>
        public ProgramsController()
        {
            _manager = new ProgramsManager();
            _logger = LogManager.GetLogger("fileLog"); ;
        }

        /// <summary>
        /// Get all programs
        /// </summary>
        /// <returns></returns>
        [Description("Get all programs")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var response = _manager.GetPrograms();
            if(!response.IsSuccessful)
                return BadRequest("An error has occurred");

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
            var request = new IdRequest { Id = id };
            var response = _manager.GetProgramsById(request);
            if (!response.IsSuccessful)
                return BadRequest("An error has occured");

            return Ok(response);
        }

        // <summary>
        // Get all courses for a particular program and semester as well as additional information if the courses are mandatory and their prerequisites
        // </summary>
        // <param name = "id" > The ID of the program</param>
        // <param name = "semester" > The number of the semester</param>
        // <returns></returns>
        [Description("Get Courses based on Semester and Program")]
        [HttpGet]
        [Route("programs/{id}/{semester}")]
        public IHttpActionResult GetProgramCourses(int id, int semester)
        {
            var request = new GetProgramCoursesRequest { ProgramId = id, Semester = semester };
            var response = _manager.GetProgramCourses(request);

            if (!response.IsSuccessful)
                return BadRequest("An error has occurred");

            return Ok(response);
        }

    }
}