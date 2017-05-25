using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class GradeGateway:CommonGateway
    {
        public List<Grade> AllGrade()
        {
            Query = "SELECT * FROM Grades";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Grade> GradeList = new List<Grade>();
            while (Reader.Read())
            {
                Grade aGrade = new Grade();
                aGrade.Id = Convert.ToInt32(Reader["Id"]);
                aGrade.Name = Reader["Name"].ToString();

                GradeList.Add(aGrade);
            }
            Reader.Close();
            Connection.Close();
            return GradeList;

        }
    }
}