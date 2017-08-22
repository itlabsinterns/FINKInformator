﻿using ItLabs.FinkInformator.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace ItLabs.FinkInformator.Core.Interfaces
{
    public interface ICoursesRepository
    {
        IQueryable<Course> GetAllCourses();
        Course GetCourseById(int id);
        List<Course> GetCoursePrerequisites(int id);
    }
}
