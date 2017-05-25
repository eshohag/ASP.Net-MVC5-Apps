using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityRegistrationProcess.Models
{
    public class ViewAllocatedClassRoom
    {
        public int DeptId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public string StartFrom { get; set; }
        public string EndTo { get; set; }
        public string RoomName { get; set; }
        public string DaysName { get; set; }

    }
}