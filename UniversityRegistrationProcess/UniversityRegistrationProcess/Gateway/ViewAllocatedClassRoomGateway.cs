using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class ViewAllocatedClassRoomGateway : CommonGateway
    {
        public List<ViewAllocatedClassRoom> GetAllocatedClassRooms()
        {
            Query = "select * from SeipProject";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewAllocatedClassRoom> aViewAllocatedClassRooms = new List<ViewAllocatedClassRoom>();

            while (Reader.Read())
            {
                ViewAllocatedClassRoom aViewClassRoom = new ViewAllocatedClassRoom();
                aViewClassRoom.DeptId = (int)Reader["DeptId"];
                aViewClassRoom.Code = Reader["Code"].ToString();
                aViewClassRoom.Name = Reader["Name"].ToString();
                aViewClassRoom.CourseId = (int)Reader["CourseId"];
                aViewClassRoom.RoomName = Reader["RoomName"].ToString();
                aViewClassRoom.DaysName = Reader["DaysName"].ToString();
                string strtime;
                string endtime;
                if (Reader["StartFrom"] == DBNull.Value)
                {
                    strtime = "";

                }
                else
                {
                    strtime = Convert.ToDateTime(Reader["StartFrom"]).ToString("HH:mm  tt");

                }
                if (Reader["EndTo"] == DBNull.Value)
                {
                    endtime = "";
                }
                else
                {
                    DateTime EndTime = Convert.ToDateTime(Reader["EndTo"]).AddMinutes(+1);
                    endtime = EndTime.ToString("HH:mm tt");
                }
                aViewClassRoom.StartFrom = strtime;
                aViewClassRoom.EndTo = endtime;
                aViewAllocatedClassRooms.Add(aViewClassRoom);
            }
            Reader.Close();
            Connection.Close();
            return aViewAllocatedClassRooms;
        }
    }
}