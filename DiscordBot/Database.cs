using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot
{
    public class Database
    {
        private static string connectionString = string.Empty;

		public static void SetConnectionString(string host, int port, string database, string username, string password)
		{
			connectionString = "server=" + host +
							   ";database=" + database +
							   ";port=" + port +
							   ";userid=" + username +
							   ";password=" + password;
		}
	}
}
