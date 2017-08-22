using System.Collections.Generic;
using ItLabs.FinkInformator.Core.Models;
namespace ItLabs.FinkInformator.Core.Responses
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