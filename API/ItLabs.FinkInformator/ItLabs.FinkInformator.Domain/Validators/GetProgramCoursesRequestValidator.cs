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
