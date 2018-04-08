using System.Web.Mvc;
using GucciPriceIntelligence.Models;
using GucciPriceIntelligence.Models.Entities;
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
    }
}