using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCIntro.Gateway;
using MVCIntro.Models;

namespace MVCIntro.Manager
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();

        public string Save(Item item)
        {
            int rowAffected = itemGateway.Save(item);

            if (rowAffected > 0)
            {
                return "Item saved";
            }
            return "Save failed";
        }

        public List<Item> GetAllitems()
        {
            return itemGateway.GetAllItems();
        }
    }
}