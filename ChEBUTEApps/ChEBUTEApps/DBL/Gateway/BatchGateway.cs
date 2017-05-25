using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ChEBUTEApps.Models;

namespace ChEBUTEApps.DBL.Gateway
{
    public class BatchGateway:CommonGateway
    {
        public List<Batch> GetBatchList()
        {
            Query = "select * from Batch";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Batch> aBatches = new List<Batch>();
            while (Reader.Read())
            {
                Batch aBatch = new Batch();
                aBatch.ID = (int)Reader["ID"];
                aBatch.Name = Reader["Name"].ToString();
                aBatch.Year = Reader["Year"].ToString();

                aBatches.Add(aBatch);
            }
            Reader.Close();
            Connection.Close();
            return aBatches;
        }
    }
}