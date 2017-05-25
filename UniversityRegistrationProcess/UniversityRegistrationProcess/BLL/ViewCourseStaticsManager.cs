using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class ViewCourseStaticsManager
    {
        ViewCourseStaticsGateway aCourseStaticsGateway=new ViewCourseStaticsGateway();

        public List<ViewCourseStatics> AllCourseStatics()
        {

            return aCourseStaticsGateway.AllCourseStatics();
        }
    }
}