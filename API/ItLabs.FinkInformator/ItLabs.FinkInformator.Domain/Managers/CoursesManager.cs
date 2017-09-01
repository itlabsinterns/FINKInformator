using ItLabs.FinkInformator.Core.Interfaces;
using ItLabs.FinkInformator.Core.Requests;
using ItLabs.FinkInformator.Core.Responses;
using ItLabs.FinkInformator.Core.Models;
using System;
using System.Linq;
using ItLabs.FinkInformator.Domain.Validators;
using System.Collections.Generic;

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

        public CourseResponse GetCourseById(IdRequest request)
        {
            var validationResult = new IdRequestValidator().Validate(request);
            var response = new CourseResponse() { IsSuccessful = validationResult.IsValid };

            if (!response.IsSuccessful)
            {
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            try
            {
                response.Course = _coursesRepository.GetCourseById(request.Id);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while getting the specific course!");
                _logger.LogException(ex);
            }
            return response;
        }

        public GetCoursePrerequisitesResponse GetCoursePrerequisites(IdRequest request)
        {
            var validationResult = new IdRequestValidator().Validate(request);
            var response = new GetCoursePrerequisitesResponse() { IsSuccessful = validationResult.IsValid };

            if (!response.IsSuccessful)
            {
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            try
            {
                response.Prerequisites = _coursesRepository.GetCoursePrerequisites(request.Id);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while getting course prerequisites!");
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
                response.Errors.Add("An error has occurred while getting all courses!");
                _logger.LogException(ex);
            }
            return response;
        }

        public GetCourseProgramNamesResponse GetCourseProgramNames(GetCourseProgramNamesRequest request)
        {
            var validationResult = new GetCourseProgramNamesRequestValidator().Validate(request);
            var response = new GetCourseProgramNamesResponse() { IsSuccessful = validationResult.IsValid };

            if (!response.IsSuccessful)
            {
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            try
            {
                response.CourseProgramNames = _coursesRepository.GetProgramCourseNames(request.CourseName);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while getting filtered course names!");
                _logger.LogException(ex);
            }
            return response;
        }

        public CourseResponse CreateCourse(CreateCourseRequest request)
        {
            var response = new CourseResponse();

            var course = new Course()
            {
                CourseName = request.CourseName,
                CourseDescription = request.CourseDescription,
                Semester = request.Semester,
            };

            course.ProgramsCourses = request.Programs
                                         .Select(x => new ProgramsCourses
                                         {
                                             Course = course,
                                             ProgramId = x.ProgramId,
                                             IsMandatory = x.IsMandatory,
                                         });
            try
            {
                _coursesRepository.CreateCourse(course, request.Prerequisites);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                response.IsSuccessful = false;
                response.Errors.Add("An error has occurred while inserting course");
            }

            return response;
        }
    }
}
