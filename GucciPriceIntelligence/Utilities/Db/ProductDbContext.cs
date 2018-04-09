using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using GucciPriceIntelligence.Models.Entities;

namespace GucciPriceIntelligence.Utilities.Db
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(): base("DefaultConnection")
        {
        }

        public const string Product_tb_name = "Product";

        public DbSet<Product> AllProducts { get; set; }

        public List<Product> GetCategoryProducts(string categoryName)
        {
            List<Product> products = null;

            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter("@categoryName", categoryName)
            };
            products = AllProducts.SqlQuery("SELECT * FROM " + Product_tb_name +
                                            " WHERE CategoryId = (SELECT Id FROM ProductCategory WHERE Name = @categoryName)",
                paras.ToArray()).ToList();

            return products;
        }
    }
}