using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using GucciPriceIntelligence.Models.Entities;
using GucciPriceIntelligence.Utilities.Db;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GucciPriceIntelligence.Utilities
{
    public static class CountryHelper
    {
        public const string TableName = "Country";
        public const string LastUpdateFieldName = "LastUpdate";
        public const string ExchangeRateFieldName = "ExchangeRate";
        public const string CodeFieldName = "Code";
        public static List<Country> Countries;

        static CountryHelper()
        {

        }

        //Update exchange rate
        public static bool UpdateExchangeRate(string code, string to)
        {
            if (!IsExchangeRateUpdated(code))
            {
                DbHelper db = new DbHelper();
                
                WebClient webClient = new WebClient();
                string convertPatternStr = string.Format("{0}_{1}", code, to);
                string valStr = "val";

                string str = webClient.DownloadString(
                    string.Format("https://free.currencyconverterapi.com/api/v5/convert?q={0}&compact=y", 
                    convertPatternStr));

                JObject jo = (JObject) JsonConvert.DeserializeObject(str);
                float rate = float.Parse(jo[convertPatternStr][valStr].ToString());
                string curTimeStr = DateTime.Now.ToString("yyyy-MM-dd");

                db.command.CommandText = string.Format("update {0} set {1} = @rate, {2} = @curTime where {3} = @code", 
                    TableName, ExchangeRateFieldName, LastUpdateFieldName, CodeFieldName);
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@rate", rate), 
                    new SqlParameter("@curTime", curTimeStr), 
                    new SqlParameter("@code", code), 
                };
                db.command.Parameters.AddRange(parameters);
                db.ExecuteReader();

                db.Recycle();
            }

            return IsExchangeRateUpdated(code);
        }

        //Get country last update time
        public static string LastUpdateTime(string code)
        {
            string lastUpdateTime = null;

            DbHelper db = new DbHelper();

            db.command.CommandText = string.Format("select {0} from {1} where {2} = @code", LastUpdateFieldName, TableName, CodeFieldName);
            db.command.Parameters.Add("@code", SqlDbType.VarChar);
            db.command.Parameters["@code"].Value = code;

            db.connection.Open();

            db.reader = db.command.ExecuteReader();

            if (db.reader.Read())
            {
                lastUpdateTime = db.reader.GetString(0);
            }

            db.Recycle();
            return lastUpdateTime;
        }

        //Check is exchange rate updated today or not
        public static bool IsExchangeRateUpdated(string code)
        {
            bool isExchangeRateUpdated = false;

            DbHelper db = new DbHelper();

            string curTimeStr = DateTime.Now.ToString("yyyy-MM-dd");
            db.command.CommandText = string.Format("select {0} from {1} where Code = @code", LastUpdateFieldName, TableName);
            db.command.Parameters.Add("@code", SqlDbType.VarChar);
            db.command.Parameters["@code"].Value = code;

            db.ExecuteReader();
            if (db.reader.Read())
            {
                if (db.reader.GetString(0).Equals(curTimeStr)) isExchangeRateUpdated = true;
            }

            db.Recycle();
            return isExchangeRateUpdated;
        }
    }
}