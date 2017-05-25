using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class DesignationManager
    {
        DesignationGateway aDesignationGateway=new DesignationGateway();

        public List<Designation> AllDesignations()
        {
            return aDesignationGateway.GetAllDesignation();
        }
    }
}