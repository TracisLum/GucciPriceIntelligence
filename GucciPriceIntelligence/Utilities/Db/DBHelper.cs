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
        public SqlCommand command;
        public SqlDataReader reader;

        public DbHelper()
        {
            Init();
        }

        //Intialise DB entities
        private void Init()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            command = connection.CreateCommand();
        }

        //Execute DB reader
        public void ExecuteReader()
        {
            if(connection.State!= ConnectionState.Open)
                connection.Open();
            reader = command.ExecuteReader();
        }

        //Recycle DB entities memory
        public void Recycle()
        {
            if(reader!=null)
                reader.Dispose();
            connection.Close();
            connection.Dispose();
        }
    }
}