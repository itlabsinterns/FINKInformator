using System.Collections.Generic;
using ItLabs.FinkInformator.Core.Models;

namespace ItLabs.FinkInformator.Core.Responses
{
    public class GetProgramCoursesResponse:ResponseBase
    {
        public GetProgramCoursesResponse():base()
        {
            ProgramsCoursesCustom = new List<ProgramsCoursesCustom>();
        }

        public List<ProgramsCoursesCustom> ProgramsCoursesCustom { get; set; }

    }
}
