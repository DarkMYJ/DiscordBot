using DiscordBot.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DiscordBot.DataAccess
{
    public class GameDataAccess
    {
        public static string errMessage = string.Empty;

        public static bool RegisterPlayer(ulong playerID, string playerName)
        {
            bool success = true;
            using (SqlConnection db = Database.GetConnection())
            {
                try
                {
                    db.Open();
                    string insert = "INSERT INTO Player(PlayerID,PlayerName,Balance) " +
                        "values (" + playerID + ",'" + playerName + "',500)";
                    SqlCommand command = new SqlCommand(insert, db);
                    command.ExecuteNonQuery();
                    db.Close();
                }
                catch (Exception e)
                {
                    if (e.Message.ToLower().Contains("cannot insert duplicate key"))
                    {
                        errMessage = "You Cannot Register Twice...";
                    }
                    success = false;
                }
            }

            return success;
        }

        
        public static List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            
            using (SqlConnection db = Database.GetConnection())
            {
                db.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Player",db);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Player player = new Player();
                    player.Name = reader.GetString(1);
                    player.ID = (ulong) reader.GetInt64(2);
                    player.Balance = reader.GetInt64(3);

                    players.Add(player);
                }
                db.Close();
            }
            return players;
        }
    }
}
