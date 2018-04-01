using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Utilities.Db;

namespace GucciPriceIntelligence.Models.Entities
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float ExchangeRate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}