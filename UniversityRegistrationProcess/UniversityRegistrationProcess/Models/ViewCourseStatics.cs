using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class ViewCourseStatics
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester_Name { get; set; }
        public string Teacher_Name { get; set; }
        public int DeptId { get; set; }
    }
}