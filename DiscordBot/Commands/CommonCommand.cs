using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class CommonCommand : BaseCommandModule
    {

        [Command("hi")]
        [Description("Saya Hanya Ingin Menghina Kalian :v :v")]
        public async Task Greeting(CommandContext ct, params String[] pesan)
        {
            String[] kataHinaan =
                {
                    "Hello Noob",
                    "Apaan Suee",
                    "Berisik Njing",
                    "Apa Lo..",
                    "Manggil Mulu...",
                    "Bodo Amaat..."
                };
            if (pesan.Length <= 0)
            {
                var rnd = new Random();
                int index = rnd.Next(kataHinaan.Length);
                var test = ct.User.Mention;
                await ct.RespondAsync($"{kataHinaan[index]} {ct.User.Mention} ");
            }
            else
            {
                await ct.RespondAsync($"Hi {String.Join(" ", pesan)} {ct.User.Mention} ");
            }
        }

        [Command("todayDate")]
        [Description("Get Current Date")]
        public async Task GetDate(CommandContext ct)
        {
            var today = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            await ct.RespondAsync($" {today} ");
        }

        [Command("listSauce")]
        [Description("Give You List Sauce")]
        public async Task ListSauce(CommandContext ct)
        {
            string fileName = @"F:\Coba.txt";
            List<string> output = new List<string>();
            try
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] temp = s.Split(' ');
                        output.Add(temp[0]);
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            await ct.RespondAsync(String.Join("\n", output));
        }


        [Command("sauce")]
        [Description("Give You Sauce")]
        public async Task SupriseSauce(CommandContext ct,
        [Description("Your Value Or Random")]
            int index = 0)
        {
            string fileName = @"F:\Coba.txt";
            List<string> output = new List<string>();
            List<string> sauceOutput = new List<string>();

            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] temp = s.Split(' ');
                    sauceOutput.Add(s);
                    output.Add(temp[0]);
                }
            }

            if (index == 0)
            {
                var rng = new Random();
                int a = rng.Next(output.Count);
                await ct.RespondAsync(sauceOutput[a]);
            }
            else
            {
                if (index > output.Count)
                {
                    await ct.RespondAsync($"Data Doesn't Exist, You Can Select Data From 1 - {output.Count}");
                }
                else
                {
                    await ct.RespondAsync(sauceOutput[index - 1]);
                }
            }
        }

        [Command("roles")]
        [Description("Show Every Member Roles")]
        public async Task GetAllRoles(CommandContext ct)
        {
            var members = ct.Guild.Members.Values.OrderBy(a => a.DisplayName);
            var embed = new DiscordEmbedBuilder();
            embed.Title = "Roles For All Members";
            embed.Description = "I dont Know What To Write";
            embed.Color = DiscordColor.Green;
            try
            {
                await ct.RespondAsync("Getting Members Role......");
                foreach (var member in members)
                {
                    var roles = (from a in member.Roles select a).ToList();
                    if (roles.Count > 0)
                    {
                        List<string> roleBox = new List<string>();
                        foreach (var role in roles)
                        {
                            roleBox.Add("`" + role.Name + "`");
                        }
                        embed.AddField(member.DisplayName, String.Join(",", roleBox), false);
                    }
                    else
                    {
                        embed.AddField(member.DisplayName, "No Roles Assigned", false);
                    }
                }
                embed.Build();
                await ct.RespondAsync(embed: embed);
            }
            catch (Exception e)
            {
                await ct.RespondAsync(e.Message);
            }
        }
    }
}
