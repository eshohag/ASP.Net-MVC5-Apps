using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class ViewStudentDepartmentGateway:CommonGateway
    {
        public List<ViewStudentDepartment> AllStudentDepartments()
        {
            Query = "SELECT * FROM StudentWithDepartment";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewStudentDepartment> StudentList = new List<ViewStudentDepartment>();
            while (Reader.Read())
            {
                ViewStudentDepartment aStudent = new ViewStudentDepartment();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.Name = Reader["Name"].ToString();
                aStudent.RegNo = Reader["RegNo"].ToString();
                aStudent.DeptName = Reader["DeptName"].ToString();
                aStudent.DepartmentId = (int)Reader["DepartmentId"];
                aStudent.StudentId = (int)Reader["StudentId"];
                
                StudentList.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return StudentList;
        }

        public int Save(ViewStudentDepartment aStudentDepartment)
        {
            Query = "INSERT INTO Enrolls(StudentId,Name,CourseId,DeptName,Email,Date) VALUES(@StudentId,@Name,@CourseId,@DeptName,@Email,@Date)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = aStudentDepartment.StudentId;
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aStudentDepartment.Name;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = aStudentDepartment.CourseId;
            Command.Parameters.Add("DeptName", SqlDbType.VarChar);
            Command.Parameters["DeptName"].Value = aStudentDepartment.DeptName;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aStudentDepartment.Email;
            Command.Parameters.Add("Date", SqlDbType.Date);
            Command.Parameters["Date"].Value = aStudentDepartment.Date;

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;  

        }

        public ViewStudentDepartment IsExistingCourse(ViewStudentDepartment aStudentDepartment)
        {
            Query = "SELECT * FROM Enrolls WHERE CourseId=@CourseId AND StudentId=@StudentId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = aStudentDepartment.CourseId;
            Command.Parameters.Add("StudentId", SqlDbType.Int);
            Command.Parameters["StudentId"].Value = aStudentDepartment.StudentId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            ViewStudentDepartment aDepartment = null;
            while (Reader.Read())
            {
                aDepartment = new ViewStudentDepartment();
                aDepartment.CourseId = Convert.ToInt32(Reader["CourseId"]);
                aDepartment.StudentId = (int)Reader["StudentId"];
               
            }
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }
    }
}