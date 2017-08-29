using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Requests;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core;
using System;
using System.Linq;
using ItLabs.FinkInformator.Domain.Validators;
using FluentValidation.Results;

namespace ItLabs.FinkInformator.Domain.Managers
{
    public class CoursesManager : ICoursesManager
    {
        private ICoursesRepository _coursesRepository;
        private ICoreLog _logger;
        public CoursesManager(ICoursesRepository coursesRepository, ICoreLog logger)
        {
            _coursesRepository = coursesRepository;
            _logger = logger;
        }

        public GetCourseResponse GetCourseById(IdRequest request)
        {
            IdRequestValidator validator = new IdRequestValidator();
            ValidationResult result = validator.Validate(request);
            GetCourseResponse response = new GetCourseResponse();
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
                response.Course = _coursesRepository.GetCourseById(request.Id);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                _logger.LogException(ex);
            }
            return response;
        }

        public GetCoursePrerequisitesResponse GetCoursePrerequisites(IdRequest request)
        {
            IdRequestValidator validator = new IdRequestValidator();
            ValidationResult result = validator.Validate(request);
            GetCoursePrerequisitesResponse response = new GetCoursePrerequisitesResponse();
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
                response.Prerequisites = _coursesRepository.GetCoursePrerequisites(request.Id);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                _logger.LogException(ex);
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
                _logger.LogException(ex);
            }
            return response;
        }

        public GetCourseProgramNamesResponse GetCourseProgramNames(GetCourseProgramNamesRequest request)
        {
            GetCourseProgramNamesRequestValidator validator = new GetCourseProgramNamesRequestValidator();
            ValidationResult result = validator.Validate(request);
            GetCourseProgramNamesResponse response = new GetCourseProgramNamesResponse();
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
                response.CourseProgramNames = _coursesRepository.GetProgramCourseNames(request.CourseName);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add(ex.Message);
                _logger.LogException(ex);
            }
            return response;
        }
    }
}
