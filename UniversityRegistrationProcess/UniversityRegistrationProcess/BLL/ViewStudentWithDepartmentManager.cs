using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class ViewStudentWithDepartmentManager
    {
        ViewStudentWithDepartmentGateway aStudentWithDepartmentGateway=new ViewStudentWithDepartmentGateway();
        public List<ViewStudentWithDepartment> AllStudentList()
        {

            return aStudentWithDepartmentGateway.AllStudentWithDepartments();
        }
    }
}