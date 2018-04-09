using System.Web.Mvc;
using GucciPriceIntelligence.Models;
using GucciPriceIntelligence.Models.Entities;
using GucciPriceIntelligence.Models.ViewModels;
using GucciPriceIntelligence.Utilities.Db;

namespace GucciPriceIntelligence.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Category(string category)
        {
            CategoryDbContext db = new CategoryDbContext();
            CategoryViewModels categoryViewModels = new CategoryViewModels();
            categoryViewModels.CategoryName = category;
            categoryViewModels.SubCategories = db.GetSubCategoriesWithImage(category);
            return View(categoryViewModels);
        }

        public ActionResult ListProducts(string category, string subcategory)
        {
            ProductDbContext db = new ProductDbContext();
            ListProductsViewModels listProductsViewModels = new ListProductsViewModels();
            listProductsViewModels.CategoryName = subcategory;
            listProductsViewModels.Products = db.GetCategoryProducts(subcategory);
            return View(listProductsViewModels);
        }
    }
}