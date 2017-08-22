using ItLabs.FinkInformator.Data.Models;
using ItLabs.FinkInformator.Core.Models;
using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Data;
using System.Collections.Generic;
using System.Linq;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Requests;
using System;

namespace ItLabs.FinkInformator.Domain.Managers
{
    public class ProgramsManager:IProgramsManager
    {
        private IProgramsRepository _programsRepository;
        public ProgramsManager()
        {
            _programsRepository = new ProgramsRepository();
        }

        public GetProgramsResponse GetPrograms()
        {
            var response = new GetProgramsResponse();
            try
            {
                response.Programs = _programsRepository.getPrograms().ToList();
            }catch(Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public GetProgramResponse GetProgramsById(IdRequest request)
        {
            var response = new GetProgramResponse();
            try
            {
                response.Program = _programsRepository.getPrograms().Where(x => x.ProgramId == request.Id).FirstOrDefault();

            }catch(Exception ex)
            {
                
                response.Errors.Add(ex.Message);
                response.IsSuccessful = false;
            }

            return response;
        }

        public GetProgramCoursesResponse GetProgramCourses(GetProgramCoursesRequest request)
        {
            GetProgramCoursesResponse response = new GetProgramCoursesResponse();
            try
            {
                response.ProgramsCoursesCustom = _programsRepository.GetProgramCourses(request).ToList();
            }catch(Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccessful = false;
            }
            return response;
        }


    }
}
