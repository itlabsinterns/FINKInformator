using FluentValidation;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Domain.Validators
{
    class CreateCourseRequestValidator:AbstractValidator<CreateCourseRequest>
    {
        public CreateCourseRequestValidator()
        {
            RuleFor(x => x.CourseName).NotNull();
            RuleFor(x => x.Semester).InclusiveBetween(1, 8);
        }
    }
}
