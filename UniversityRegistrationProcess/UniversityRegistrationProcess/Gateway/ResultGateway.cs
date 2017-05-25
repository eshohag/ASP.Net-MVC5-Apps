using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class ResultGateway:CommonGateway
    {
        public int Save(Result aResult)
        {
            Query = "INSERT INTO Results(StudentId,Name,Email,DeptName,CourseId,GradeId) VALUES(@StudentId,@Name,@Email,@DeptName,@CourseId,@GradeId)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = aResult.StudentId;
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aResult.Name;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aResult.Email;
            Command.Parameters.Add("DeptName", SqlDbType.VarChar);
            Command.Parameters["DeptName"].Value = aResult.DeptName;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = aResult.CourseId;
            Command.Parameters.Add("GradeId", SqlDbType.Int);
            Command.Parameters["GradeId"].Value = aResult.GradeId;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;   
        }
        public Result IsExistingResult(Result aResult)
        {
            Query = "SELECT * FROM Results WHERE CourseId=@CourseId AND StudentId=@StudentId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = aResult.CourseId;
            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = aResult.StudentId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            Result aResults = null;
            while (Reader.Read())
            {
                aResults = new Result();
                aResults.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aResults.StudentId = Convert.ToInt32(Reader["StudentId"]);
               
               
            }
            Reader.Close();
            Connection.Close();
            return aResults;
        }

        public List<EnrollCourseByStudent> EnrollCourseByStudent()
        {
            Query = "SELECT * FROM ViewEnrollCourse";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            List<EnrollCourseByStudent> aViewEnrollCourses = new List<EnrollCourseByStudent>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                EnrollCourseByStudent aEnrollCourse = new EnrollCourseByStudent()
                {
                    CourseName = Reader["CourseName"].ToString(),
                    CourseId = (int)Reader["CourseId"],
                    StudentId = (int)Reader["StudentId"]
                };
                aViewEnrollCourses.Add(aEnrollCourse);
            }
            Reader.Close();
            Connection.Close();
            return aViewEnrollCourses;

        }
    }
}