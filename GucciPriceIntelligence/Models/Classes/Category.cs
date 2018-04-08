using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Classes;

namespace GucciPriceIntelligence.Models.Entities
{
    public class Category : BaseModelClass
    {
        public string CategoryName { get; set; }
        public int CategoryLevel { get; set; }
    }
}