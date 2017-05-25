using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class DaysManager
    {
        DaysGateway aDaysGateway=new DaysGateway();
        public List<Day> AllDays()
        {
            return aDaysGateway.GetDays();
        } 
    }
}