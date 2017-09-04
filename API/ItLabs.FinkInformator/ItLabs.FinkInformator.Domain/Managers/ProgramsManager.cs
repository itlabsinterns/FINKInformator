using ItLabs.FinkInformator.Core.Interfaces;
using System.Linq;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;
using System;
using ItLabs.FinkInformator.Domain.Validators;
using ItLabs.FinkInformator.Core.Models;
using ItLabs.FinkInformator.Domain.Extensions;

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
                response.Programs = _programsRepository.GetPrograms().ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while getting all programs!");
                _logger.LogException(ex);
            }
            return response;
        }


        public ProgramResponse GetProgramsById(IdRequest request)
        {
            var response = new IdRequestValidator().Validate(request).ToResponse<ProgramResponse>();
            if (!response.IsSuccessful)
                return response;

            try
            {
                response.Program = _programsRepository.GetProgramById(request.Id);
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
            var response = new GetProgramCoursesRequestValidator().Validate(request).ToResponse<GetProgramCoursesResponse>();
            if (!response.IsSuccessful)
                return response;

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
        public ProgramResponse CreateProgram(CreateProgramRequest request)
        {
            var response = new CreateProgramRequestValidator().Validate(request).ToResponse<ProgramResponse>();
            if (!response.IsSuccessful)
                return response;

            var program = new Program { ProgramName = request.ProgramName };
            try
            {
                response.Program = _programsRepository.CreateProgram(program);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while creating the program!");
            }
            return response;
        }
        public ProgramResponse UpdateProgram(UpdateProgramRequest request)
        {
            var response = new UpdateProgramRequestValidator().Validate(request).ToResponse<ProgramResponse>();
            if (!response.IsSuccessful)
                return response;

            try
            {
                var programToUpdate = _programsRepository.GetPrograms().Where(x => x.ProgramId == request.IdToUpdate).FirstOrDefault();
                if (programToUpdate != null)
                {
                    programToUpdate.ProgramName = request.Program.ProgramName;
                    _programsRepository.UpdateProgram(programToUpdate);
                    response.Program = programToUpdate;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while changing the program!");
                _logger.LogException(ex);
            }
            return response;
        }

        public ResponseBase DeleteProgram(IdRequest request)
        {
            var response = new IdRequestValidator().Validate(request).ToResponse<ResponseBase>();
            if (!response.IsSuccessful)
                return response;

            try
            {
                _programsRepository.RemoveProgram(_programsRepository.GetProgramById(request.Id));
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while deleting the program!");
                _logger.LogException(ex);
            }
            return response;
        }
    }
}
