using GoContributeMe.Gateway;
using GoContributeMe.Models.Model;
using GoContributeMe.Models.ViewModel;
using System.Collections.Generic;

namespace GoContributeMe.BLL
{
    public class UserManager
    {
        UserGateway aUserGateway = new UserGateway();
        public string SaveUserInfo(User aUser)
        {
            if (aUserGateway.EmailCheck(aUser) == null)
            {
                if (aUserGateway.UserNameCheck(aUser) == null)
                {
                    if (aUserGateway.SaveUserInfo(aUser) > 0)
                    {
                        return "Success";
                    }
                }
            }
            return "Failed Saved userName or Email already Entered ! ";
        }
        public User IsExisting(User anUser)
        {
            return aUserGateway.IsExistingUser(anUser);
        }


        public int ContactInfoCustomer(ContactUs contactUs)
        {

            return aUserGateway.ContactInfoSave(contactUs);
        }

        public List<ViewAllDataInfo> SearchKey(string searchKey)
        {
            return aUserGateway.SearchKey(searchKey);
        }
    }
}