using ItLabs.FinkInformator.Api.Models;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class ProgramsResponse : ResponseBase
    {
        public ProgramsResponse() : base()
        {
            Programs = new List<Program>();
        }

        public List<Program> Programs;
    }
}