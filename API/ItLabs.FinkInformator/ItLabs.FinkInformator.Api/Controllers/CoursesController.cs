﻿using ItLabs.FinkInformator.Api.Models;
using ItLabs.FinkInformator.Api.Responses;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Cors;
using System;
using ItLabs.FinkInformator.Api.Requests;
using NLog;

namespace ItLabs.FinkInformator.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController : ApiController
    {
        private SchoolContext _schoolContext;
        private Logger _logger;

        public CoursesController()
        {
            _schoolContext = new SchoolContext();
            _logger = LogManager.GetLogger("databaseLogger");
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var response = new GetCoursesResponse();
            try
            {
                throw new Exception();
                response.Courses = _schoolContext.Courses.ToList();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error has occurred!");

                return BadRequest("An error has occurred");
            }

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetCourse(int id)
        {
            var response = new GetCourseResponse();
            var request = new IdRequest { Id = id };

            if (request.Id <= 0)
            {
                response.IsSuccessful = false;
                response.Errors.Add("Invalid parameter: id");

                return Ok(response);
            }
            try
            {
                response.Course = _schoolContext.Courses.Where(x => x.CourseId == request.Id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "An error has occurred!");

                return BadRequest("An error has occurred");
            }

            return Ok(response);
        }
    }
}