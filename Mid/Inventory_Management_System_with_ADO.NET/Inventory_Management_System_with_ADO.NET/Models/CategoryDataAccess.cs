using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory_Management_System_with_ADO.NET.Models
{
    public class CategoryDataAccess
    {
        DataAccess dataAccess;

        public CategoryDataAccess()
        {
            this.dataAccess = new DataAccess();
        }

        public List<Category> GetAllCategories()
        {
            string sql = "SELECT * FROM Categories ";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Category> categoryList = new List<Category>();
            while (reader.Read())
            {
                Category cat = new Category();
                cat.CategoryId = (int)reader["CategoryId"];
                cat.CategoryName = (string)reader["CategoryName"].ToString();
               categoryList.Add(cat);
            }
            return categoryList;
        }

        public int InsertCategory(Category cate)
        {
            string sql = "INSERT INTO Categories(CategoryName) VALUES('" + cate.CategoryName + "')";
            return dataAccess.ExecuteQuery(sql);
        }

    }
}