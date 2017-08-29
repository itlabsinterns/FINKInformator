using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
