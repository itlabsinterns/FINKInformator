using System.Web.Http;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Requests;
using System.Web.Http.Cors;
using System.ComponentModel;
using System.Web.Http.Description;
using ItLabs.FinkInformator.Core.Responses;

namespace ItLabs.FinkInformator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class ProgramsController : ApiController
    {
        private IProgramsManager _manager;
        ///<summary>
        ///Programs Controller Constructor
        /// </summary>
        /// <returns></returns>
        public ProgramsController(IProgramsManager programsManager)
        {
            _manager = programsManager;
        }

        /// <summary>
        /// Get all programs
        /// </summary>
        /// <returns></returns>
        [Description("Get all programs")]
        [ResponseType(typeof(GetProgramsResponse))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var response = _manager.GetPrograms();
            if (!response.IsSuccessful)
                return BadRequest(response.ToString());

            return Ok(response);
        }

        /// <summary>
        /// Get a particular program
        /// </summary>
        /// <param name="id">The ID of the requested program</param>
        /// <returns></returns>
        [Description("Get Program by Id")]
        [ResponseType(typeof(ProgramResponse))]
        [Route("programs/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var request = new IdRequest { Id = id };
            var response = _manager.GetProgramsById(request);
            if (!response.IsSuccessful)
                return BadRequest(response.ToString());

            return Ok(response);
        }

        /// <summary>
        /// Get all courses for a particular program and semester as well as additional information if the courses are mandatory and their prerequisites
        /// </summary>
        ///<param name = "id" > The ID of the program</param>
        /// <param name = "semester" > The number of the semester</param>
        /// <returns></returns>
        [Description("Get Courses based on Semester and Program")]
        [ResponseType(typeof(GetProgramCoursesResponse))]
        [HttpGet]
        [Route("programs/{id}/{semester}")]
        public IHttpActionResult GetProgramCourses(int id, int semester)
        {
            var request = new GetProgramCoursesRequest { ProgramId = id, Semester = semester };
            var response = _manager.GetProgramCourses(request);

            if (!response.IsSuccessful)
                return BadRequest(response.ToString());

            return Ok(response);
        }
        /// <summary>
        /// Add a new program
        /// </summary>
        /// <param Program = "ProgramName" > Name of the program </param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateProgram([FromBody]CreateProgramRequest request)
        {
            var response = _manager.CreateProgram(request);
            if (!response.IsSuccessful)
                return BadRequest(response.ToString());
            return Ok(response);
        }
        /// <summary>
        /// Update a Program
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateProgram([FromBody]UpdateProgramRequest request)
        {
            var response = _manager.UpdateProgram(request);
            if (!response.IsSuccessful)
            {
                return BadRequest(response.ToString());
            }
            return Ok(response);
        }
        /// <summary>
        /// Delete a Program
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteProgram([FromBody]IdRequest request)
        {
            var response = _manager.DeleteProgram(request);
            if (!response.IsSuccessful)
                return BadRequest(response.ToString());
            return Ok(response);
        }

    }
}