using System.Collections.Generic;
using ItLabs.FinkInformator.Core.Models;

namespace ItLabs.FinkInformator.Core.Responses
{
    public class GetProgramCoursesResponse : ResponseBase
    {
        public GetProgramCoursesResponse() : base()
        {
            ProgramsCoursesDto = new List<ProgramCoursesDto>();
        }

        public List<ProgramCoursesDto> ProgramsCoursesDto { get; set; }

    }
}
