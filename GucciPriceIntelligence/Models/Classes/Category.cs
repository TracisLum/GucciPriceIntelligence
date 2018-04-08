using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Classes;

namespace GucciPriceIntelligence.Models.Classes
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CatLevel { get; set; }
        public int ParentCateId { get; set; }
        public string ImageUrl { get; set; }
    }
}