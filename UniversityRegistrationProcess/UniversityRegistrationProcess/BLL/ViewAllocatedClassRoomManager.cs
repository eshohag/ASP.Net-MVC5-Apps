using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class ViewAllocatedClassRoomManager
    {
        ViewAllocatedClassRoomGateway aAllocatedClassRoomGateway = new ViewAllocatedClassRoomGateway();

        public List<ViewAllocatedClassRoom> GetAllViewAllocatedClassRoom()
        {


            return aAllocatedClassRoomGateway.GetAllocatedClassRooms();
        }
    }
}