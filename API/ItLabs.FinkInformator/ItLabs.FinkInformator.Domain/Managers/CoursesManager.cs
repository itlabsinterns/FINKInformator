using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Requests;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Data.Repositories;
using System;
using System.Linq;

namespace ItLabs.FinkInformator.Domain.Managers
{
    public class CoursesManager:ICoursesManager
    {
        private ICoursesRepository _coursesRepository;
        public CoursesManager()
        {
            _coursesRepository = new CoursesRepository();
        }

        public GetCourseResponse GetCourseById(IdRequest request)
        {
            GetCourseResponse response = new GetCourseResponse();
            try
            {
                response.Course = _coursesRepository.GetCourseById(request.Id);
            }catch(Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public GetCoursePrerequisitesResponse GetCoursePrerequisites(IdRequest request)
        {
            GetCoursePrerequisitesResponse response = new GetCoursePrerequisitesResponse();
            try
            {
                response.Prerequisites = _coursesRepository.GetCoursePrerequisites(request.Id);
            }catch(Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
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
            }
            return response;
        }

        public GetCourseProgramNamesResponse getCourseProgramNames(GetCourseProgramNamesRequest request)
        {
            GetCourseProgramNamesResponse response = new GetCourseProgramNamesResponse();
            try
            {
                response.CourseProgramNames = _coursesRepository.getProgramCourseNames(request.CourseName);
            }catch(Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}
