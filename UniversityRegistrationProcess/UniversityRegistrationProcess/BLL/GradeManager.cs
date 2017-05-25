using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class GradeManager
    {
        GradeGateway aGradeGateway=new GradeGateway();

        public List<Grade> AllGrades()
        {
            return aGradeGateway.AllGrade();
        }
    }
}