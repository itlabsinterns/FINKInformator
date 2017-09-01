using FluentValidation;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Domain.Validators
{
    class CreateProgramRequestValidator:AbstractValidator<CreateProgramRequest>
    {
        public CreateProgramRequestValidator()
        {
            RuleFor(x => x.ProgramName).NotNull();
        }
    }
}
