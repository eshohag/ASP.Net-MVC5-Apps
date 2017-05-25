using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.Gateway
{
    public class ClassRoomGateway:CommonGateway
    {
        public int Save(AllocateClassRoom allocateClassRoom)
        {
            Query = "INSERT INTO ClassRoom(DepartmentId,CourseId,RoomId,DaysId,FromId,ToId,StatusId) VALUES(@DepartmentId,@CourseId,@RoomId,@DaysId,@FromId,@ToId,@StatusId)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.Add("DepartmentId", SqlDbType.Int);
            Command.Parameters["DepartmentId"].Value = allocateClassRoom.DepartmentId;
            Command.Parameters.Add("CourseId", SqlDbType.Int);
            Command.Parameters["CourseId"].Value = allocateClassRoom.CourseId;
            Command.Parameters.Add("RoomId", SqlDbType.Int);
            Command.Parameters["RoomId"].Value = allocateClassRoom.RoomId;
            Command.Parameters.Add("DaysId", SqlDbType.Int);
            Command.Parameters["DaysId"].Value = allocateClassRoom.DaysId;
            Command.Parameters.Add("FromId", SqlDbType.DateTime);
            Command.Parameters["FromId"].Value = allocateClassRoom.FromId;
            Command.Parameters.Add("ToId", SqlDbType.DateTime);
            Command.Parameters["ToId"].Value = allocateClassRoom.ToId;
            Command.Parameters.Add("StatusId", SqlDbType.Int);
            Command.Parameters["StatusId"].Value = 1;

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;    

        }
        public int IsExistingRoom(int roomId, DateTime fromId, DateTime toId, int daysId)
        {
            Query = "select COUNT(*) from ClassRoom as a where (a.FromId >='" + fromId + "' and  a.FromId <='" + fromId + "') and  (a.ToId <='" + toId + "' and  a.ToId >='" + toId + "') and DaysId ='" + daysId + "' and RoomId= '" + roomId + "' and StatusId='1' ";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            int rowCount = (int)Command.ExecuteScalar();
          
            Connection.Close(); 
            return rowCount;

        }
    }
}