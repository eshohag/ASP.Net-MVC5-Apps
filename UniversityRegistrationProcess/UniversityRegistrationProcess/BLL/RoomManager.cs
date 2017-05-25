using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class RoomManager
    {
        RoomGateway aRoomGateway=new RoomGateway();

        public List<Room> GetRooms()
        {
            return aRoomGateway.GetRooms();
        }}
    
}