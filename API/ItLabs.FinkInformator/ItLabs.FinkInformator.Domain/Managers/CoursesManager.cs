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

        public GetCourseResponse GetCourseById(IdRequest request)
        {
            var validationResult = new IdRequestValidator().Validate(request);
            var response = new GetCourseResponse() { IsSuccessful = validationResult.IsValid };

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

        public ResponseBase AddCourse(PostCourseRequest request)
        {
            var response = new ResponseBase();
            try
            {
                var course = new Course()
                {
                    CourseId = request.CourseId,
                    CourseName = request.CourseName,
                    CourseDescription = request.CourseDescription,
                    Semester = request.Semester
                };
                var programsCourses = new List<ProgramsCourses>();
                foreach (var item in request.Programs)
                {
                    programsCourses.Add(new ProgramsCourses()
                    {
                        CourseId = course.CourseId,
                        ProgramId = item.ProgramId,
                        IsMandatory = item.IsMandatory
                    });
                }

                course.ProgramsCourses = programsCourses;
                var coursePrerequisites = new List<CoursesPrerequisites>();
                foreach (var prerequisite in request.Prerequisites)
                {
                    coursePrerequisites.Add(new CoursesPrerequisites()
                    {
                        Course = course,
                        Prerequisite = _coursesRepository.GetCourseById(prerequisite)
                    });
                }

                _coursesRepository.AddCourse(course, coursePrerequisites);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                response.IsSuccessful = false;
                response.Errors.Add("An error has occured while inserting course");
            }
            return response;
        }
    }
}
