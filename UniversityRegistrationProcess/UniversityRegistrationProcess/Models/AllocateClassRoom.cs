using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class AllocateClassRoom
    {
        public int AllocateClassRoomId { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int DaysId { get; set; }
        public DateTime FromId { get; set; }
        public DateTime ToId { get; set; }
    }
}