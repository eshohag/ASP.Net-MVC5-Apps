using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway=new TeacherGateway();
        public string Save(Teacher aTeacher)
        {
            if (aTeacherGateway.IsExistingCourse(aTeacher) == null)
            {
                if (aTeacherGateway.Save(aTeacher) > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return "Failed Save";
                }
            }
            else
            {
                return "Email Address Already Exists "+aTeacher.Email;
            }
           
            
        }

        public List<Teacher> AllTeachers()
        {
            return aTeacherGateway.GetAllTeachers();
        } 
    }
}