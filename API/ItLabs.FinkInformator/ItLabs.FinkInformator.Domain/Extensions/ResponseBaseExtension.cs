using FluentValidation.Results;
using ItLabs.FinkInformator.Core.Responses;
using System.Linq;

namespace ItLabs.FinkInformator.Domain.Extensions
{
    public static class ResponseBaseExtension
    {
        public static T ToResponse<T>(this ValidationResult validationResult) where T: ResponseBase
        {
            var response = new ResponseBase();

            response.IsSuccessful = validationResult.IsValid;
            response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));

            return response as T;
        }
    }
}
