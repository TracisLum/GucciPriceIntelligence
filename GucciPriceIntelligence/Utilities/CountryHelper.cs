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

        public static string LastUpdateTime(string code)
        {
            DbHelper dbHelper = new DbHelper();
            SqlConnection conn = dbHelper.connection;
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select CONVERT(varchar(10), LastUpdate, 23) from " + TableName + " where Code = @code";
            //cmd.Parameters.Add("@lastupdate", SqlDbType.VarChar);
            cmd.Parameters.Add("@code", SqlDbType.VarChar);
            cmd.Parameters["@code"].Value = code;

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetString(0);
            }

            conn.Close();
            conn.Dispose();
            return "false";
        }

        //Check is exchange rate updated today or not
        public static bool IsExchangeRateUpdated(string code)
        {
            DbHelper dbHelper = new DbHelper();
            SqlConnection conn = dbHelper.connection;
            SqlCommand cmd = conn.CreateCommand();

            string curTimeStr = DateTime.Now.ToString("yyyy-MM-dd");
            cmd.CommandText = "select CONVERT(varchar(10), " + LastUpdateFieldName + ", 23) from " + TableName + " where Code = @code";
            cmd.Parameters.Add("@code", SqlDbType.VarChar);
            cmd.Parameters["@code"].Value = code;

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetString(0).Equals(curTimeStr)) return true;
            }

            conn.Close();
            conn.Dispose();
            return false;
        }
    }
}