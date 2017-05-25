using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class DesignationGateway:CommonGateway
    {
        public List<Designation> GetAllDesignation()
        {
            Query = "SELECT * FROM Designation";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> DesignationList = new List<Designation>();
            while (Reader.Read())
            {
                Designation aDesignation = new Designation();
                aDesignation.DesignationId = Convert.ToInt32(Reader["DesignationId"]);
                aDesignation.Name = Reader["Name"].ToString();

                DesignationList.Add(aDesignation);
            }
            Reader.Close();
            Connection.Close();
            return DesignationList;
        }
    }
}