using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class SemesterGateway:CommonGateway
    {
        public List<Semester> GetAllSemesters()
        {
            Query = "SELECT * FROM Semester";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> SemesterList = new List<Semester>();
            while (Reader.Read())
            {
                Semester aSemester = new Semester();
                aSemester.SemesterId = Convert.ToInt32(Reader["SemesterId"]);
                aSemester.Name = Reader["Name"].ToString();

                SemesterList.Add(aSemester);
            }
            Reader.Close();
            Connection.Close();
            return SemesterList;
        }


    }
}