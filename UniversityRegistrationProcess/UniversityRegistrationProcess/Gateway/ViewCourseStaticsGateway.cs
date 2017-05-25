using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class ViewCourseStaticsGateway:CommonGateway
    {
        public List<ViewCourseStatics> AllCourseStatics()
        {
            Query = @"Select Code,Name,Semester_Name,ISNULL(Teacher_Name,'Not Assign Yet')AS Teacher_Name, DepartmentId From ViewAllCourseStatics";
            //Query = "Select * from ViewAllCourseStatics";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewCourseStatics> CourseList = new List<ViewCourseStatics>();
            while (Reader.Read())
            {
                ViewCourseStatics aCourse = new ViewCourseStatics();
                aCourse.Code = Reader["Code"].ToString();
                aCourse.Name = Reader["Name"].ToString();
                aCourse.Semester_Name = Reader["Semester_Name"].ToString();
                
                aCourse.Teacher_Name = Reader["Teacher_Name"].ToString();
                aCourse.DeptId = Convert.ToInt32(Reader["DepartmentId"]);
              

                CourseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return CourseList; 

        }
       
    }
}