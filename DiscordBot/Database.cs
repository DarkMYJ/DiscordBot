using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DiscordBot
{
    public class Database
    {
        private static string connectionString = string.Empty;
        private static SqlConnectionStringBuilder builder;

        public static void SetConnectionString(string host, int port, string database, string username, string password)
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = host;
            builder.UserID = username;
            builder.Password = password;
            builder.InitialCatalog = database;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(builder.ConnectionString);
        }

    }
}
