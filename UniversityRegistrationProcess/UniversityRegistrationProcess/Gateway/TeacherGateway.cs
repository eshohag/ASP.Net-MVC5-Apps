using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class TeacherGateway:CommonGateway
    {
        public int Save(Teacher aTeacher)
        {
            Query = "INSERT INTO Teachers(Name,Email,ContactNo,Address,DesignationId,DepartmentId,CreditToBeTaken,RemainingCredit) VALUES(@Name,@Email,@ContactNo,@Address,@DesignationId,@DepartmentId,@CreditToBeTaken,@RemainingCredit)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aTeacher.Name;
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aTeacher.Email;
            Command.Parameters.Add("ContactNo", SqlDbType.VarChar);
            Command.Parameters["ContactNo"].Value = aTeacher.ContactNo;
            Command.Parameters.Add("Address", SqlDbType.VarChar);
            Command.Parameters["Address"].Value = aTeacher.Address;
             Command.Parameters.Add("DesignationId", SqlDbType.VarChar);
            Command.Parameters["DesignationId"].Value = aTeacher.DesignationId;
            Command.Parameters.Add("DepartmentId", SqlDbType.VarChar);
            Command.Parameters["DepartmentId"].Value = aTeacher.DepartmentId;
            Command.Parameters.Add("CreditToBeTaken", SqlDbType.Decimal);
            Command.Parameters["CreditToBeTaken"].Value = aTeacher.CreditToBeTaken;
            Command.Parameters.Add("RemainingCredit", SqlDbType.Decimal);
            Command.Parameters["RemainingCredit"].Value = aTeacher.CreditToBeTaken;

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;    
        }
        public Teacher IsExistingCourse(Teacher aTeacherSearch)
        {
            Query = "SELECT * FROM Teachers WHERE Email=@Email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Email", SqlDbType.VarChar);
            Command.Parameters["Email"].Value = aTeacherSearch.Email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            Teacher aTeacher = null;
            while (Reader.Read())
            {
                aTeacher = new Teacher();
                aTeacher.Email = Reader["Email"].ToString();
               
            }
            Reader.Close();
            Connection.Close();
            return aTeacher;
        }
        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT * FROM Teachers";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> TeacherList = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher();
                aTeacher.TeacherId = (int)Reader["TeacherId"];
                aTeacher.Name = Reader["Name"].ToString();
                aTeacher.Email = Reader["Email"].ToString();
                aTeacher.Address = Reader["Address"].ToString();
                aTeacher.ContactNo = Reader["ContactNo"].ToString();
                aTeacher.CreditToBeTaken = (decimal)Reader["CreditToBeTaken"];
                aTeacher.RemainingCredit = (decimal)Reader["RemainingCredit"];
                aTeacher.DesignationId = (int) Reader["DesignationId"];
                aTeacher.DepartmentId = (int) Reader["DepartmentId"];

                TeacherList.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return TeacherList;
        }

        public int UpdateCreditToRemainCredit(decimal remainCredit, int teacherId)
        {
            Query = "UPDATE Teachers SET RemainingCredit='" + remainCredit + "' Where TeacherId='" + teacherId + "' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}