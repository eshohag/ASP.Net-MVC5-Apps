
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityRegistrationProcess.Models;


namespace UniversityRegistrationProcess.Gateway
{
    public class ViewResultGateway:CommonGateway
    {
        public List<ViewResultStudent> GetAllViewResults()
        {
            Query = "Select StudentId,CourseId,Code,CourseName, ISNULL(GradeName,'Not Grade Yet') AS GradeName from ViewResult";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewResultStudent> aStudentListResult = new List<ViewResultStudent>();
            while (Reader.Read())
            {
                ViewResultStudent aStudent = new ViewResultStudent();
                aStudent.StudentId = (int) Reader["StudentId"];
                aStudent.CourseId = (int)Reader["CourseId"];                          
                aStudent.Code = Reader["Code"].ToString();
                aStudent.CourseName = Reader["CourseName"].ToString();               
                aStudent.GradeName = Reader["GradeName"].ToString();

                aStudentListResult.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return aStudentListResult; 
        }
    }
}