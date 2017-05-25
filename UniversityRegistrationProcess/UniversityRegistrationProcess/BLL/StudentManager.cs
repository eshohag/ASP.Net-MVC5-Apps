using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();
        public string Save(Student aStudent)
        {
            if (aStudentGateway.IsExistingStudent(aStudent) == null)
            {
                if (aStudentGateway.Save(aStudent) > 0)
                {
                    return "Your Registration Number is "+aStudent.RegNo;
                }
                else
                {
                    return "failed Save";
                }
            }

            else
            {
                return " Student  Already Exists " + aStudent.Name;
            }

        }


        public int GetRowCount(string regno)
        {

            int count = aStudentGateway.GetRowCount(regno);
            return count;
        }

        public List<Student> AllStudentInfo()
        {
            return aStudentGateway.AllStudentInfo();
        } 
    }
}