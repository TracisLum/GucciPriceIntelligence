using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Classes;

namespace GucciPriceIntelligence.Models.Entities
{
    public class Product : BaseModelClass
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
    }
}