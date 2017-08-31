using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core;
using System.Linq;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;
using System;
using ItLabs.FinkInformator.Domain.Validators;
using FluentValidation.Results;
using ItLabs.FinkInformator.Domain.Extensions;
using ItLabs.FinkInformator.Core.Models;

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
                response.Errors.Add("An error has occurred while getting all programs!");
                _logger.LogException(ex);
            }
            return response;
        }
        public ResponseBase AddProgram(Program program)
        {
            var response = new ResponseBase();
            try
            {
                _programsRepository.AddProgram(program);
            }
            catch(Exception ex)
            {
                _logger.LogException(ex);
                response.IsSuccessful = false;
                response.Errors.Add("Something went wrong");
            }
            return response;
        }

        public GetProgramResponse GetProgramsById(IdRequest request)
        {
            var validationResult = new IdRequestValidator().Validate(request);
            var response = new GetProgramResponse() { IsSuccessful = validationResult.IsValid };

            if (!response.IsSuccessful)
            {
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            try
            {
                response.Program = _programsRepository.getPrograms().Where(x => x.ProgramId == request.Id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while getting the specific program!");
                _logger.LogException(ex);
            }

            return response;
        }

        public GetProgramCoursesResponse GetProgramCourses(GetProgramCoursesRequest request)
        {
            var validationResult = new GetProgramCoursesRequestValidator().Validate(request);
            var response = new GetProgramCoursesResponse() { IsSuccessful = validationResult.IsValid };

            if (!response.IsSuccessful)
            {
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            try
            {
                response.ProgramsCoursesDto = _programsRepository.GetProgramCourses(request).ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while getting program courses!");
                _logger.LogException(ex);
            }
            return response;
        }

        public ResponseBase ModifyProgram(int id, Program program)
        {
            var response = new ResponseBase();
            try
            {
                var programToModify = _programsRepository.getPrograms().Where(x => x.ProgramId == id).FirstOrDefault();
                if (programToModify != null)
                {
                    programToModify.ProgramName = program.ProgramName;
                    _programsRepository.ChangeProgram(programToModify);
                }              
            }
            catch(Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while changing the program!");
                _logger.LogException(ex);
            }
            return response;
        }
    }
}
