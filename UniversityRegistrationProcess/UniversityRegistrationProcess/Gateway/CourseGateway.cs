using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class CourseGateway:CommonGateway
    {
        public int Save(Course aCourse)
        {
            Query = "INSERT INTO Courses(Code,Name,Credit,Description,DepartmentId,SemesterId) VALUES(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("Code", SqlDbType.VarChar);
            Command.Parameters["Code"].Value = aCourse.Code;
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aCourse.Name;
            Command.Parameters.Add("Credit", SqlDbType.Decimal);
            Command.Parameters["Credit"].Value = aCourse.Credit;
            Command.Parameters.Add("Description", SqlDbType.VarChar);
            Command.Parameters["Description"].Value = aCourse.Description;
            Command.Parameters.Add("DepartmentId", SqlDbType.VarChar);
            Command.Parameters["DepartmentId"].Value = aCourse.DepartmentId;
            Command.Parameters.Add("SemesterId", SqlDbType.VarChar);
            Command.Parameters["SemesterId"].Value = aCourse.SemesterId;

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;    
        }
        public Course IsExistingCourse(Course aCourseSearch)
        {
            Query = "SELECT * FROM Courses WHERE Code=@Code OR Name=@Name";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Code", SqlDbType.VarChar);
            Command.Parameters["Code"].Value = aCourseSearch.Code;
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aCourseSearch.Name;
            Connection.Open();
            Reader = Command.ExecuteReader();
            Course aCourse = null;
            while (Reader.Read())
            {
                aCourse = new Course();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourse.Code = Reader["Code"].ToString();
                aCourse.Name = Reader["Name"].ToString();  
            }
            Reader.Close();
            Connection.Close();
            return aCourse;
        }
        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM Courses";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> CourseList = new List<Course>();
            while (Reader.Read())
            {
                Course aCourse = new Course();
                aCourse.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aCourse.Name = Reader["Name"].ToString();
                aCourse.Code = Reader["Code"].ToString();
                aCourse.Credit = (decimal)Reader["Credit"];
                aCourse.DepartmentId = (int)Reader["DepartmentId"];
                aCourse.Description = Reader["Description"].ToString();
                aCourse.SemesterId = (int)Reader["SemesterId"];

                CourseList.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return CourseList;
        }

        public int SaveAssignCourseToTeacher(AssignTeacher aAssignTeacher)
        {
            Query = "INSERT INTO AssignTeachers(DepartmentId,TeacherId,CourseId) VALUES(@DepartmentId,@TeacherId,@CourseId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = aAssignTeacher.DepartmentId;
            Command.Parameters.Add("TeacherId", SqlDbType.Int);
            Command.Parameters["TeacherId"].Value = aAssignTeacher.TeacherId;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = aAssignTeacher.CourseId;
           
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;  
        }
        public AssignTeacher IsExistingAssignTeacher(AssignTeacher aAssignTeacher)
        {
            Query = "SELECT * FROM AssignTeachers WHERE CourseId=@CourseId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = aAssignTeacher.CourseId;

            Connection.Open();
            Reader = Command.ExecuteReader();
            AssignTeacher assignTeacher = null;
            while (Reader.Read())
            {
                assignTeacher = new AssignTeacher();
                assignTeacher.CourseId = Convert.ToInt32(Reader["CourseId"]);

            }
            Reader.Close();
            Connection.Close();
            return assignTeacher;
        }
    }
}