using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class Result
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DeptName { get; set; }
        public int CourseId { get; set; }
        public int GradeId { get; set; }
    }
}