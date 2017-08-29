﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Domain.Validators
{
    class GetProgramCoursesRequestValidator: AbstractValidator<GetProgramCoursesRequest>
    {
        public GetProgramCoursesRequestValidator()
        {
            RuleFor(request => request.ProgramId).GreaterThan(0);
            RuleFor(request => request.Semester).ExclusiveBetween(0, 9);
        }
    }
}
