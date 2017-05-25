using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class ClassRoomManager
    {
        private ClassRoomGateway aClassRoomGateway = new ClassRoomGateway();

        public string Save(AllocateClassRoom allocateClassRoom)
        {
            allocateClassRoom.ToId = allocateClassRoom.ToId.AddMinutes(-1);
            int rowCount = aClassRoomGateway.IsExistingRoom(allocateClassRoom.RoomId, allocateClassRoom.FromId, allocateClassRoom.ToId, allocateClassRoom.DaysId);

            if (rowCount == 0)
            {
                if (aClassRoomGateway.Save(allocateClassRoom) > 0)
                {
                    return " Class Room Allocated sucessfully";
                }
                else
                {
                    return " Class Room Allocation failed";
                }
            }
            else
            {
                return "Already Allocated a Class Room";
            }


        }
        
    }
}