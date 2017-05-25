
using GoContributeMe.Models.Model;
using GoContributeMe.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GoContributeMe.Gateway
{
    public class UserGateway : CommonGateway
    {
        public User IsExistingUser(User anUser)
        {
            Query = "SELECT * FROM Users WHERE UserName='" + anUser.UserName + "' and Password='" + anUser.Password + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            User aUserOne = null;
            while (Reader.Read())
            {
                aUserOne = new User();
                aUserOne.Name = Reader["Name"].ToString();
                aUserOne.UserID = Convert.ToInt32(Reader["UserID"]);

            }
            Reader.Close();
            Connection.Close();
            return aUserOne;
        }


        public int SaveUserInfo(User aUser)
        {
            Query = "INSERT INTO Users VALUES('" + aUser.Name + "','" + aUser.Email + "','" + aUser.UserName + "','" + aUser.Password + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public int ContactInfoSave(ContactUs contactUs)
        {

            Query = "INSERT INTO ContactUs VALUES('" + contactUs.Name + "','" + contactUs.Email + "','" + contactUs.Description + "','" + contactUs.Date + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public string EmailCheck(User aUser)
        {
            Query = "SELECT * FROM Users WHERE Email='" + aUser.Email + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string aUserOne = null;
            while (Reader.Read())
            {

                aUserOne = Reader["Email"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aUserOne;
        }

        public string UserNameCheck(User aUser)
        {
            Query = "SELECT * FROM Users WHERE UserName='" + aUser.UserName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            string aUserOne = null;
            while (Reader.Read())
            {

                aUserOne = Reader["UserName"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aUserOne;
        }

        public int Subscriber(string email)
        {
            Query = "INSERT INTO Subscriber VALUES('" + email + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<ViewAllDataInfo> SearchKey(string searchKey)
        {
            Query = "select * from ViewAllDataInfo where Tittle like '%" + searchKey + "%'       ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewAllDataInfo> aCampaignist = new List<ViewAllDataInfo>();
            while (Reader.Read())
            {
                ViewAllDataInfo aCampaign = new ViewAllDataInfo();
                aCampaign.CampaignID = (int)Reader["CampaignID"];
                aCampaign.Tittle = Reader["Tittle"].ToString();
                aCampaign.CategoriesName = Reader["CategoriesName"].ToString();
                aCampaign.ContributionsName = Reader["ContributionsName"].ToString();

                aCampaign.Descriptions = Reader["Descriptions"].ToString();
                aCampaign.RecipientName = Reader["RecipientName"].ToString();
                aCampaign.RecipientNID = Reader["RecipientNID"].ToString();
                aCampaign.Email = Reader["Email"].ToString();
                aCampaign.TargetAmount = Reader["TargetAmount"].ToString();
                aCampaign.CampaignClosingDate = (DateTime)Reader["CampaignClosingDate"];
                aCampaign.MobileNo = Reader["MobileNo"].ToString();
                aCampaignist.Add(aCampaign);
            }
            Reader.Close();
            Connection.Close();
            return aCampaignist;

        }

        public List<ViewAllDataInfo> AllData()
        {
            Query = "select * from ViewAllDataInfo";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewAllDataInfo> aCampaignist = new List<ViewAllDataInfo>();
            while (Reader.Read())
            {
                ViewAllDataInfo aCampaign = new ViewAllDataInfo();
                aCampaign.CampaignID = (int)Reader["CampaignID"];
                aCampaign.Tittle = Reader["Tittle"].ToString();
                aCampaign.CategoriesName = Reader["CategoriesName"].ToString();
                aCampaign.ContributionsName = Reader["ContributionsName"].ToString();

                aCampaign.Descriptions = Reader["Descriptions"].ToString();
                aCampaign.RecipientName = Reader["RecipientName"].ToString();
                aCampaign.RecipientNID = Reader["RecipientNID"].ToString();
                aCampaign.Email = Reader["Email"].ToString();
                aCampaign.TargetAmount = Reader["TargetAmount"].ToString();
                aCampaign.CampaignClosingDate = (DateTime)Reader["CampaignClosingDate"];
                aCampaign.MobileNo = Reader["MobileNo"].ToString();
                aCampaignist.Add(aCampaign);
            }
            Reader.Close();
            Connection.Close();
            return aCampaignist;

        }
    }
}