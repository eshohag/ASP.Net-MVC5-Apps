using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class EnrollCourseByStudent
    {
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}