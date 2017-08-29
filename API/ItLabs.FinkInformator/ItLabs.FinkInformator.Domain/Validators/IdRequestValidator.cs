using FluentValidation;
using ItLabs.FinkInformator.Core.Requests;

namespace ItLabs.FinkInformator.Domain.Validators
{
    class IdRequestValidator: AbstractValidator<IdRequest>
    {
        public IdRequestValidator()
        {
            RuleFor(idRequest => idRequest.Id).GreaterThan(0);
        }
    }
}
