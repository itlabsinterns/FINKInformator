using ItLabs.FinkInformator.Api.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class GetProgramsResponse : ResponseBase
    {
        public GetProgramsResponse()
        {
            Programs = new List<Program>();
        }

        public List<Program> Programs;
    }
}