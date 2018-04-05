using System.Web.Mvc;
using GucciPriceIntelligence.Models.Entities;

namespace GucciPriceIntelligence.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Category(string cat_1)
        {
            var category = new ProductCategory();
            category.Name = cat_1;
            category.Level = 0;
            return View(category);
        }
    }
}