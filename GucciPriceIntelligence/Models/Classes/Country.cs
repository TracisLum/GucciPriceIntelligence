using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Models.Classes;
using GucciPriceIntelligence.Utilities.Db;

namespace GucciPriceIntelligence.Models.Entities
{
    public class Country : BaseModelClass
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public float CountryExchangeRate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}