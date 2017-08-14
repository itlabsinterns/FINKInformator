    using ItLabs.FinkInformator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class ProgramsResponse : ResponseBase
    {
        //Property containing all Programs
        public List<Program> Programs;

        //Class constructor
        public ProgramsResponse() : base()
        {
            this.Programs = new List<Program>();
        }

    }
}