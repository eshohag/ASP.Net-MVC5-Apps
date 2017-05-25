using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MVCIntro.Models;

namespace MVCIntro.Gateway
{
    public class ItemGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["ItemDBConnString"].ConnectionString;
        public int Save(Item item)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Items (name, price, category_id) VALUES ('" + item.Name + "', '" + item.Price + "', '" + item.CategoryId + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;

        }

        public List<Item> GetAllItems()
        {
            string query = "SELECT * FROM Items";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Item> items = new List<Item>();

            while (reader.Read())
            {
                Item item = new Item()
                {
                    Id = (int)reader["id"],
                    Name = reader["name"].ToString(),
                    Price = Convert.ToDecimal(reader["price"]),
                    CategoryId = (int) reader["category_id"]
                };

                items.Add(item);
            }
            reader.Close();
            connection.Close();


            return items;
        }
    }
}