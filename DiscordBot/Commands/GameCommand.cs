using DiscordBot.DataAccess;
using DiscordBot.Model;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class GameCommand :BaseCommandModule
    {
        [Command("register")]
        [Description("Register Player To Play Game")]
        public async Task RegisterPlayer(CommandContext ct,DiscordMember member)
        {

            bool result = GameDataAccess.RegisterPlayer(member.Id,member.DisplayName);

            if(result)
            {
                await ct.RespondAsync("Thank You For Registering..");
            }
            else
            {
                await ct.RespondAsync(GameDataAccess.errMessage);
            }
        }

        [Command("players")]
        [Description("Show List Of Registered Player")]
        public async Task GetAllPlayer(CommandContext ct)
        {
            List<Player> players = GameDataAccess.GetAllPlayers();
            var embed = new DiscordEmbedBuilder
            {
                Title = "Player List",
                Description = "This Show All Player That Have Registered",
                Color = DiscordColor.Aquamarine
            };
            for(int i = 0;i<players.Count;i++)
            {
                string desc = "`Player ID :` "+players[i].ID+"\n`Player Name :` "+players[i].Name+"\n`Current Balance :` "+players[i].Balance;
                embed.AddField("Player : "+(i+1),desc,false);
            }
            await ct.RespondAsync(embed:embed);
        }
    }
}
