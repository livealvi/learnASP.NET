using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory_Management_System_with_ADO.NET.Models
{
    public class ProductDataAccess
    {
        DataAccess dataAccess;

        public ProductDataAccess()
        {
            this.dataAccess = new DataAccess();
        }

        public List<Product> GetAllProducts()
        {
            string sql = "SELECT * FROM Products";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Product> productList = new List<Product>();
            while (reader.Read())
            {
                Product pro = new Product();
                pro.ProductId = (int)reader["ProductId"];
                pro.ProductName = (string)reader["ProductName"].ToString();
                pro.Price = Convert.ToDouble(reader["Price"]);
                pro.CategoryId = (int)reader["CategoryId"];
                productList.Add(pro);
            }
            return productList;
        }
        public int InsertProduct(Product pro)
        {
            string sql = "INSERT INTO Products(ProductName,Price,CategoryId) VALUES('" + pro.ProductName + "', "+pro.Price+", "+pro.CategoryId+")";
            return dataAccess.ExecuteQuery(sql);
        }

        public Product GetProductById(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductId=" + id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Product pro = new Product();
            pro.ProductId = (int)reader["ProductId"];
            pro.ProductName = (string)reader["ProductName"].ToString();
            pro.Price = Convert.ToDouble(reader["Price"]);
            pro.CategoryId = (int)reader["CategoryId"];

            return pro;
        }

        public int UpdateProduct(Product pro)
        {
            string sql = "UPDATE Products SET ProductName='" + pro.ProductName + "', Price='"+pro.Price+ "', CategoryId='"+pro.CategoryId+ "'  WHERE ProductId=" + pro.ProductId;
            return dataAccess.ExecuteQuery(sql);
        }

        public int DeleteProduct(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId=" + id;
            return dataAccess.ExecuteQuery(sql);
        }

    }
}