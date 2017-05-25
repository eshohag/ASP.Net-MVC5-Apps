using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class ViewStudentWithDepartmentGateway:CommonGateway
    {
        public List<ViewStudentWithDepartment> AllStudentWithDepartments()
        {
            Query = "Select * from StudentWithDepartment";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewStudentWithDepartment> aStudentList = new List<ViewStudentWithDepartment>();
            while (Reader.Read())
            {
                ViewStudentWithDepartment aStudent = new ViewStudentWithDepartment();
                aStudent.Name = Reader["Name"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DeptName = Reader["DeptName"].ToString();
                aStudent.RegNo = Reader["RegNo"].ToString();
                aStudent.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                aStudent.StudentId = Convert.ToInt32(Reader["StudentId"]);
                aStudentList.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return aStudentList; 
        } 
    }
}