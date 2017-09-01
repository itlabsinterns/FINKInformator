using FluentValidation;
using ItLabs.FinkInformator.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.FinkInformator.Domain.Validators
{
    public class UpdateCourseRequestValidator: AbstractValidator<UpdateCourseRequest>
    {
        public UpdateCourseRequestValidator()
        {
            RuleFor(x => x.CourseName).NotNull();
            RuleFor(x => x.Semester).InclusiveBetween(1,8);
        }
    }
}
