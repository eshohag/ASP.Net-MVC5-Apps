using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChEBUTEApps.DBL.Gateway;
using ChEBUTEApps.Models;

namespace ChEBUTEApps.BBL
{
    public class BatchManager
    {
        BatchGateway aBatchGateway=new BatchGateway();

        public List<Batch> GetBatchList()
        {
            return aBatchGateway.GetBatchList();
        }
    }
}