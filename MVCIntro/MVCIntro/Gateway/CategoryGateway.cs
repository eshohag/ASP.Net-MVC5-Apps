using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MVCIntro.Models;

namespace MVCIntro.Gateway
{
    public class CategoryGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["ItemDBConnString"].ConnectionString;

        public List<Category> GetAllCategories()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Categories";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (reader.Read())
            {
                Category category = new Category()
                {
                    Id = (int) reader["id"],
                    Name = reader["name"].ToString()
                };

                categories.Add(category);
            }

            reader.Close();
            connection.Close();

            return categories;
        }
    }
}