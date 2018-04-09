using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Classes;

namespace GucciPriceIntelligence.Models.Entities
{
    public class Product
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double USD { get; set; }
        public double CNY { get; set; }
    }
}