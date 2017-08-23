using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Requests;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core;
using System;
using System.Linq;

namespace ItLabs.FinkInformator.Domain.Managers
{
    public class CoursesManager : ICoursesManager
    {
        private ICoursesRepository _coursesRepository;
        public CoursesManager(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        public GetCourseResponse GetCourseById(IdRequest request)
        {
            GetCourseResponse response = new GetCourseResponse();
            try
            {
                response.Course = _coursesRepository.GetCourseById(request.Id);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                CoreLog.LogError(ex);
            }
            return response;
        }

        public GetCoursePrerequisitesResponse GetCoursePrerequisites(IdRequest request)
        {
            GetCoursePrerequisitesResponse response = new GetCoursePrerequisitesResponse();
            try
            {
                response.Prerequisites = _coursesRepository.GetCoursePrerequisites(request.Id);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                CoreLog.LogError(ex);
            }
            return response;
        }

        public GetCoursesResponse GetCourses()
        {
            GetCoursesResponse response = new GetCoursesResponse();
            try
            {
                response.Courses = _coursesRepository.GetAllCourses().ToList();
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                CoreLog.LogError(ex);
            }
            return response;
        }

        public GetCourseProgramNamesResponse GetCourseProgramNames(GetCourseProgramNamesRequest request)
        {
            var response = new GetCourseProgramNamesResponse();

            try
            {
                response.CourseProgramNames = _coursesRepository.GetProgramCourseNames(request.CourseName);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                CoreLog.LogError(ex);
            }
            return response;
        }
    }
}
