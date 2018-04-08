using System.Web.Mvc;
using GucciPriceIntelligence.Models.Entities;

namespace GucciPriceIntelligence.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Category(string categoryName)
        {
            var category = new Category();
            category.Name = categoryName;
            ViewBag.Title = categoryName;
            return View(category);
        }
    }
}