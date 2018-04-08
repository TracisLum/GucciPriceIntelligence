using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GucciPriceIntelligence.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
    }
}