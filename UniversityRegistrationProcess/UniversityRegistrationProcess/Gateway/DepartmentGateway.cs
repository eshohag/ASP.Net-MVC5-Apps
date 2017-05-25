using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class DepartmentGateway:CommonGateway
    {
        public int Save(Department aDepartment)
        {
            Query = "INSERT INTO Department(deptCode,deptName) VALUES(@deptCode,@deptName)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("deptCode", SqlDbType.VarChar);
            Command.Parameters["deptCode"].Value =aDepartment.DeptCode;
            Command.Parameters.Add("deptName", SqlDbType.VarChar);
            Command.Parameters["deptName"].Value = aDepartment.DeptName;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;                 
        }
        public Department IsExistingDepartment(Department aDepartmentSearch)
        {
            Query = "SELECT * FROM Department WHERE deptCode=@deptCode OR deptName=@deptName";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("deptCode", SqlDbType.VarChar);
            Command.Parameters["deptCode"].Value = aDepartmentSearch.DeptCode;
            Command.Parameters.Add("deptName", SqlDbType.VarChar);
            Command.Parameters["deptName"].Value = aDepartmentSearch.DeptName;
            Connection.Open();
            Reader = Command.ExecuteReader();
            Department aDepartment = null;
            while (Reader.Read())
            {
                aDepartment = new Department();
                aDepartment.DeptId = Convert.ToInt32(Reader["deptId"]);
                aDepartment.DeptCode = Reader["deptCode"].ToString();
                aDepartment.DeptName = Reader["deptName"].ToString();  
            }      
            Reader.Close();
            Connection.Close();
            return aDepartment;
        }
        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department";
            Command = new SqlCommand(Query, Connection);                     
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> DepartmentList = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment=new Department();
                aDepartment.DeptId = Convert.ToInt32(Reader["deptId"]);
                aDepartment.DeptCode = Reader["deptCode"].ToString();
                aDepartment.DeptName = Reader["deptName"].ToString();
                DepartmentList.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return DepartmentList;
        }
    }
}