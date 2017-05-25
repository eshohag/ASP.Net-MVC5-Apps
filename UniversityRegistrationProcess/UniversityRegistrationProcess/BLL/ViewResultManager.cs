using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class ViewResultManager
    {
        ViewResultGateway aViewResultGateway=new ViewResultGateway();
        public List<ViewResultStudent> GetAllResults()
        {

            return aViewResultGateway.GetAllViewResults();
        }
    }
}