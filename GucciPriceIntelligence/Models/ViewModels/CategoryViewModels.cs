using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Classes;

namespace GucciPriceIntelligence.Models
{
    public class CategoryViewModels
    {
        public string CategoryName { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}