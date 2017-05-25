using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using MVCIntro.Manager;
using MVCIntro.Models;

namespace MVCIntro.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public string Find(int? id, string name)
        //{
        //    if (id == 1)
        //    {
        //        return "Item with id 1";
        //    }
        //    else if (id == 2)
        //    {
        //        return "Item with id 2";
        //    }
        //    else
        //    {
        //        return "No item found";
        //    }
        //}

        ItemManager itemManager = new ItemManager();
        CategoryManager categoryManager = new CategoryManager();

        //public string Save(Item item)
        //{
        //    return itemManager.Save(item);
        //}

        public ActionResult Save()
        {
            List<Category> categories = categoryManager.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Save(Item item)
        {
            List<Category> categories = categoryManager.GetAllCategories();
            ViewBag.Categories = categories;
            ViewBag.Message = itemManager.Save(item);
            return View();
        }

        public ActionResult Index()
        {
            List<Item> items = itemManager.GetAllitems();
            return View(items);
        }

        public string Find(int id)
        {
            return GetAllItems().FirstOrDefault(item => item.Id == id).Name;
        }

        private List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>()
            {
                new Item(){Id = 1, Name = "Burger", Price = 150},
                new Item(){Id = 2, Name = "Pizza", Price = 750},
                new Item(){Id = 3, Name = "Ice Cream", Price = 200}
            };

            return items;
        }
    }
}