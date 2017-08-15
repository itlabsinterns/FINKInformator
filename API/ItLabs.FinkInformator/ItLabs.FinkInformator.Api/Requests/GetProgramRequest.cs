using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItLabs.FinkInformator.Api.Requests
{
    public class GetProgramRequest
    {
        public GetProgramRequest(int? id =null)
        {
            if (id.HasValue)
                Id = id.Value;
            
        }
        public int Id { get; set; }
    }
}