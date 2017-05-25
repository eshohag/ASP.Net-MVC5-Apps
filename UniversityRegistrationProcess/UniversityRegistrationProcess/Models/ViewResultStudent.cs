using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class ViewResultStudent
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DeptName { get; set; }
        public string RegNo { get; set; }
        public string CourseName { get; set; }
        public string Code { get; set; }
        public int CourseId { get; set; }
        public string GradeName { get; set; }
    }
}