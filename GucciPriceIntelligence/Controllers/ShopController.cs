using System.Web.Mvc;
using GucciPriceIntelligence.Models.Entities;

namespace GucciPriceIntelligence.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Category(string category)
        {
            var categoryInstance = new Category();
            categoryInstance.PageName = category;
            categoryInstance.CategoryName = category;
            return View(categoryInstance);
        }
    }
}