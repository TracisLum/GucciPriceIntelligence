using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Classes;

namespace GucciPriceIntelligence.Utilities.Db
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext() : base("DefaultConnection")
        {
        }

        public const string Category_tb_name = "ProductCategory";

        public DbSet<Category> AllCategories { get; set; }

        public List<Category> GetSubCategoriesWithImage(string parentCateName)
        {
            List<Category> subcategories = null;
            int parentCateId = GetCategoryId(parentCateName);
            if (parentCateId != -1)
            {
                List<SqlParameter> paras = new List<SqlParameter>()
                {
                    new SqlParameter("@parentCateId", parentCateId)
                };
                subcategories = AllCategories.SqlQuery("SELECT * FROM "+Category_tb_name+" WHERE ParentCateId = @parentCateId AND ImageUrl IS NOT NULL",
                    paras.ToArray()).ToList();
            }

            return subcategories;
        }

        public int GetCategoryId(string cateName)
        {
            int id = -1;
            
            List<SqlParameter> paras = new List<SqlParameter>()
            {
                new SqlParameter("@cate_name", cateName)
            };
            var category = AllCategories.SqlQuery(("SELECT * FROM "+Category_tb_name+" WHERE Name = @cate_name"), paras.ToArray()).Single();
            if (category != null)
            {
                id = category.Id;
            }

            return id;
        }
    }
}