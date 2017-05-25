using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class ViewStudentDepartmentManager
    {
        ViewStudentDepartmentGateway aStudentDepartmentGateway=new ViewStudentDepartmentGateway();

        public List<ViewStudentDepartment> AllStudentDepartments()
        {
            return aStudentDepartmentGateway.AllStudentDepartments();
        }

        public string Save(ViewStudentDepartment aStudentDepartment)
        {
            if (aStudentDepartmentGateway.IsExistingCourse(aStudentDepartment) == null)
            {
                if (aStudentDepartmentGateway.Save(aStudentDepartment) > 0)
                {
                    return "Student course enrolled";
                }
                else
                {
                    return "Enroling failed";
                }
            }
            else
            {
                return "Course already Enrolled by the student ";
            }
        }
    }
}