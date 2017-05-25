using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class CourseManager
    {
        CourseGateway aCourseGateway=new CourseGateway();
        TeacherGateway aTeacherGateway=new TeacherGateway();
        public string Save(Course aCourse)
        {
            if (aCourseGateway.IsExistingCourse(aCourse) == null)
            {
                if (aCourseGateway.Save(aCourse) > 0)
                {
                    return "Saved Successfully";
                }
                else
                {
                    return " Save Failed";
                }
            }
            else
            {
                return "Course Already Entered Our database";
            }            
        }

        public string SaveAssignCourseToTeacher(AssignTeacher aAssignTeacher)
        {
            if (aCourseGateway.IsExistingAssignTeacher(aAssignTeacher)==null)
            {

                if (aCourseGateway.SaveAssignCourseToTeacher(aAssignTeacher) > 0)
                {
                    decimal remainCredit = aAssignTeacher.RemainingCredit - aAssignTeacher.Credit;
                    aTeacherGateway.UpdateCreditToRemainCredit(remainCredit, aAssignTeacher.TeacherId);
                    return "Course Assigend sucessfully Saved";
                }
                else
                {
                    return "Course Assigend Failed";
                }
          
            }
            else
            {
                return "Course Already Assigned  " + aAssignTeacher.Name;
            }
               
            
        }

        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }


            
    }
}