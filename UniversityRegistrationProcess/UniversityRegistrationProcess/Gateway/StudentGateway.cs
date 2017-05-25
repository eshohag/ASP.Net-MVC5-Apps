using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class StudentGateway:CommonGateway
    {
        public int Save(Student aStudent)
        {
            Query = "INSERT INTO Students(Name,Email,ContactNo,Date,Address,DepartmentCode,RegNo) VALUES(@Name,@Email,@ContactNo,@Date,@Address,@DepartmentCode,@RegNo)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

          
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aStudent.Name;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aStudent.Email;
            Command.Parameters.Add("ContactNo", SqlDbType.VarChar);
            Command.Parameters["ContactNo"].Value = aStudent.ContactNo;
            Command.Parameters.Add("Date", SqlDbType.DateTime);
            Command.Parameters["Date"].Value = aStudent.Date;
            Command.Parameters.Add("Address", SqlDbType.VarChar);
            Command.Parameters["Address"].Value = aStudent.Address;
            Command.Parameters.Add("DepartmentCode", SqlDbType.VarChar);
            Command.Parameters["DepartmentCode"].Value = aStudent.DepartmentCode;
            Command.Parameters.Add("RegNo", SqlDbType.VarChar);
            Command.Parameters["RegNo"].Value = aStudent.RegNo;
         

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected; 

        }
        public Student IsExistingStudent(Student aStudent)
        {
            Query = "SELECT * FROM Students WHERE Email=@Email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aStudent.Email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            Student aStudentC = null;
            while (Reader.Read())
            {
                aStudentC = new Student();
                aStudentC.Email = Reader["Email"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aStudentC;
        }

        public int GetRowCount(string regno)
        {

            Query = "Select count(*) from Students where RegNo  LIKE '%" + regno + "%'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = (int)Command.ExecuteScalar();
            Connection.Close();
            return rowAffected;
        }

        public List<Student> AllStudentInfo()
        {
            Query = "SELECT * FROM Students";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> StudentList = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.StudentId = (int) Reader["StudentId"];
                aStudent.Name = Reader["Name"].ToString();
                aStudent.DepartmentCode = Reader["DepartmentCode"].ToString();
                aStudent.RegNo = Reader["RegNo"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.Address = Reader["Address"].ToString();
                aStudent.ContactNo = Reader["ContactNo"].ToString();
                aStudent.Date = (DateTime)Reader["Date"];
                StudentList.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return StudentList;

        }
       
    }
}