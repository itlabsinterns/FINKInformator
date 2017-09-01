using FluentValidation;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Domain.Validators
{
    class GetCourseProgramNamesRequestValidator: AbstractValidator<GetCourseProgramNamesRequest>
    {
        public GetCourseProgramNamesRequestValidator()
        {
            RuleFor(request => request.CourseName).NotNull().NotEmpty();
        }
    }
}
