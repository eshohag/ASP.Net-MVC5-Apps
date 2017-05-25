using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway=new SemesterGateway();

        public List<Semester> GetAllSemesters()
        {
            return aSemesterGateway.GetAllSemesters();
        }
    }
}