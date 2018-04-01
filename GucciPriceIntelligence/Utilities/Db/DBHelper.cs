using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GucciPriceIntelligence.Utilities.Db
{
    public class DbHelper
    {
        public SqlConnection connection;

        public DbHelper()
        {
            OpenConnection();
        }

        //Open _connection
        public bool OpenConnection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                //if (connection.State.ToString() != "Open")
                //{
                //    connection.Open();
                //}
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        //Close _connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}