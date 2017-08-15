using ItLabs.FinkInformator.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class GetProgramResponse:ResponseBase
    {
        public Program Program { get; set; }
    }
}