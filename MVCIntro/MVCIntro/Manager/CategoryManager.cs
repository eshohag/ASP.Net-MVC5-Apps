using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCIntro.Gateway;
using MVCIntro.Models;

namespace MVCIntro.Manager
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }
    }
}