using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Entities;

namespace GucciPriceIntelligence.Models.ViewModels
{
    public class ListProductsViewModels
    {
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}