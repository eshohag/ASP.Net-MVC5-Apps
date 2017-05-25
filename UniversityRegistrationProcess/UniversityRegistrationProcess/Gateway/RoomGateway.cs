using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class RoomGateway:CommonGateway
    {
        public List<Room> GetRooms()
        {
            Query = "SELECT * FROM Room";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Room> RoomList = new List<Room>();
            while (Reader.Read())
            {
                Room aRoom = new Room();
                aRoom.Id = Convert.ToInt32(Reader["Id"]);
                aRoom.Number = Reader["Number"].ToString();
                RoomList.Add(aRoom);
            }
            Reader.Close();
            Connection.Close();
            return RoomList;

        }
    }
}