using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class DaysGateway:CommonGateway
    {
        public List<Day> GetDays()
        {
            Query = "SELECT * FROM Days";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Day> DayList = new List<Day>();
            while (Reader.Read())
            {
                Day aDay = new Day();
                aDay.Id = Convert.ToInt32(Reader["Id"]);
                aDay.Name = Reader["Name"].ToString();
                DayList.Add(aDay);
            }
            Reader.Close();
            Connection.Close();
            return DayList;


        }
    }
}