using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class ViewStudentDepartment
    {
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DeptName { get; set; }
        public string RegNo { get; set; }
        public string CourseName { get; set; }
        public int CourseId { get; set; }
        public DateTime Date { get; set; }
    }
}