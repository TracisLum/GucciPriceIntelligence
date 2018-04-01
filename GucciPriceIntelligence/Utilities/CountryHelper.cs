using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GucciPriceIntelligence.Utilities.Db;

namespace GucciPriceIntelligence.Utilities
{
    public static class CountryHelper
    {
        public const string TableName = "Country";
        public const string LastUpdateFieldName = "LastUpdate";

        //Update exchange rate
        public static bool UpdateExchangeRate()
        {
            DbHelper dbHelper = new DbHelper();
            SqlConnection conn = dbHelper.connection;
            SqlCommand cmd = conn.CreateCommand();



            return dbHelper.CloseConnection();
        }

        //Check is exchange rate updated today or not
        public static bool IsExchangeRateUpdated(string code)
        {
            DbHelper dbHelper = new DbHelper();
            SqlConnection conn = dbHelper.connection;
            SqlCommand cmd = conn.CreateCommand();

            string curTimeStr = DateTime.Now.ToString("yyyy-MM-dd-");
            //Select CONVERT(varchar(100), GETDATE(), 23)
            cmd.CommandText = "select CONVERT(varchar(10), @lastupdate, 23) from " + TableName + "where code = @code";
            cmd.Parameters.Add("@lastupdate", SqlDbType.VarChar);
            cmd.Parameters["@lastupdate"].Value = LastUpdateFieldName;
            cmd.Parameters.Add("@code", SqlDbType.VarChar);
            cmd.Parameters["@code"].Value = code;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetString(0).Equals(curTimeStr)) return true;
            }
            return false;
        }
    }
}