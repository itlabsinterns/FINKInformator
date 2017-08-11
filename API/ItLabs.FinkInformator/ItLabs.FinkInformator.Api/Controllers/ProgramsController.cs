using System.Web.Http;
using ItLabs.FinkInformator.Api.Responses;


namespace ItLabs.FinkInformator.Api.Controllers
{
    public class ProgramsController: ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            ProgramsResponse Response = new ProgramsResponse();
            if(!Response.IsSuccessful)
            {
                return BadRequest(Response.ToString());
            }
            return Ok(Response.Programs);
        }

    }
}