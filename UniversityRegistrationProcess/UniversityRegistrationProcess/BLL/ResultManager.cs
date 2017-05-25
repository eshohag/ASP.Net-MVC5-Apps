using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityRegistrationProcess.Gateway;
using UniversityRegistrationProcess.Models;

namespace UniversityRegistrationProcess.BLL
{
    public class ResultManager
    {
        ResultGateway aResultGateway=new ResultGateway();
        public string Save(Result aResult)
        {
            if (aResultGateway.IsExistingResult(aResult) == null)
            {
                if (aResultGateway.Save(aResult) > 0)
                {
                    return " Result Saved";
                }
                else
                {
                    return "Failed Save ";
                }
            }
            else
            {
                return "Result Already Assigned ";
            }
           
        }

        public List<EnrollCourseByStudent> GetAllEnrolledCourse()
        {
            return aResultGateway.EnrollCourseByStudent();
        }
    }
}