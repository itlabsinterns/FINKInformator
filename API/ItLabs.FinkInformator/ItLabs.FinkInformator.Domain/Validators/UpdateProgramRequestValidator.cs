using FluentValidation;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Domain.Validators
{
    class UpdateProgramRequestValidator : AbstractValidator<UpdateProgramRequest>
    {
        public UpdateProgramRequestValidator()
        {
            RuleFor(request => request.Program.ProgramName).NotNull();
            RuleFor(request => request.IdToUpdate).GreaterThan(0);
        }
    }
}
