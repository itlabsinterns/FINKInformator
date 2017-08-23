using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core;
using System.Linq;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;
using System;

namespace ItLabs.FinkInformator.Domain.Managers
{
    public class ProgramsManager : IProgramsManager
    {
        private IProgramsRepository _programsRepository;
        public ProgramsManager(IProgramsRepository programsRepository)
        {
            _programsRepository = programsRepository;
        }

        public GetProgramsResponse GetPrograms()
        {
            var response = new GetProgramsResponse();
            try
            {
                response.Programs = _programsRepository.getPrograms().ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                CoreLog.LogError(ex);
            }
            return response;
        }

        public GetProgramResponse GetProgramsById(IdRequest request)
        {
            var response = new GetProgramResponse();
            try
            {
                response.Program = _programsRepository.getPrograms().Where(x => x.ProgramId == request.Id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccessful = false;
                CoreLog.LogError(ex);
            }

            return response;
        }

        public GetProgramCoursesResponse GetProgramCourses(GetProgramCoursesRequest request)
        {
            GetProgramCoursesResponse response = new GetProgramCoursesResponse();
            try
            {
                response.ProgramsCoursesCustom = _programsRepository.GetProgramCourses(request).ToList();
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccessful = false;
                CoreLog.LogError(ex);
            }
            return response;
        }


    }
}
