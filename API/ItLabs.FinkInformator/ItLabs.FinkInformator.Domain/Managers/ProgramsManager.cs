using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core;
using System.Linq;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;
using System;
using ItLabs.FinkInformator.Domain.Validators;
using FluentValidation.Results;

namespace ItLabs.FinkInformator.Domain.Managers
{
    public class ProgramsManager : IProgramsManager
    {
        private IProgramsRepository _programsRepository;
        private ICoreLog _logger;
        public ProgramsManager(IProgramsRepository programsRepository, ICoreLog logger)
        {
            _programsRepository = programsRepository;
            _logger = logger;
        }

        public GetProgramsResponse GetPrograms()
        {
            GetProgramsResponse response = new GetProgramsResponse();
            try
            {
                response.Programs = _programsRepository.getPrograms().ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                _logger.LogException(ex);
            }
            return response;
        }

        public GetProgramResponse GetProgramsById(IdRequest request)
        {
            IdRequestValidator validator = new IdRequestValidator();
            ValidationResult result = validator.Validate(request);
            var response = new GetProgramResponse();
            if (!result.IsValid)
            {
                response.IsSuccessful = false;
                foreach (var error in result.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
                return response;
            }

            try
            {
                response.Program = _programsRepository.getPrograms().Where(x => x.ProgramId == request.Id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccessful = false;
                _logger.LogException(ex);
            }

            return response;
        }

        public GetProgramCoursesResponse GetProgramCourses(GetProgramCoursesRequest request)
        {
            GetProgramCoursesRequestValidator validator = new GetProgramCoursesRequestValidator();
            ValidationResult result = validator.Validate(request);
            GetProgramCoursesResponse response = new GetProgramCoursesResponse();
            if (!result.IsValid)
            {
                response.IsSuccessful = false;
                foreach (var error in result.Errors)
                {
                    response.Errors.Add(error.ErrorMessage);
                }
                return response;
            }

            try
            {
                response.ProgramsCoursesCustom = _programsRepository.GetProgramCourses(request).ToList();
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccessful = false;
                _logger.LogException(ex);
            }
            return response;
        }


    }
}
