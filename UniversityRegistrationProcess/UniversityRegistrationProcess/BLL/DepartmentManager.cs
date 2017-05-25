using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway=new DepartmentGateway();
        public string Save(Department aDepartment)
        {
            if (aDepartmentGateway.IsExistingDepartment(aDepartment) != null)
            {
                return "  Department Already Exists";
            }
            else
            {
                if (aDepartmentGateway.Save(aDepartment) > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Saved Failed";
                }              
            }        
        }

        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        } 
    }
}