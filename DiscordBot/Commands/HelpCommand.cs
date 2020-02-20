using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class HelpCommand : BaseCommandModule
    {
        [Command("help")]
        [Description("Show List Of Command, and Their Use")]
        public async Task ListHelp(CommandContext ct, string ctx = "", string command = "")
        {
            try
            {
                var embed = new DiscordEmbedBuilder();
                if (ctx.Equals(""))
                {
                    embed.Title = "List Command";
                    embed.Description = "This Is List Of Available Command";
                    embed.Color = DiscordColor.Gold;
                    List<string> fieldData = new List<string>();
                    foreach (var item in ct.CommandsNext.RegisteredCommands.OrderBy(a => a.Value.Name))
                    {
                        if (!string.IsNullOrEmpty(item.Value.Description))
                        {
                            fieldData.Add("`<?" + item.Value.Name + ">`: " + item.Value.Description);
                        }
                        else
                        {
                            fieldData.Add("`<?" + item.Value.Name + ">`: No Description Provided For This Command");
                        }
                    }
                    fieldData.Add("`<?help command>`: Will Give You Full Description For The Given Command");
                    embed.AddField("Commands", String.Join("\n", fieldData), false);
                    embed.Build();
                }
                else
                {
                    var temp = ct.CommandsNext.RegisteredCommands.Where(a => a.Key.ToLower() == ctx.ToLower()).Select(a => a.Value).FirstOrDefault();
                    if (temp != null)
                    {
                        embed.Title = temp.Name;
                        embed.Description = temp.Description;
                        embed.Color = DiscordColor.Gold;
                        List<string> argList = new List<string>();
                        var arguments = temp.Overloads[0].Arguments;
                        if (arguments.Count > 0)
                        {
                            foreach (var argument in arguments)
                            {
                                string desc = argument.Description;
                                if (!string.IsNullOrEmpty(desc))
                                {
                                    argList.Add("`<" + argument.Name + ">: " + argument.Type.Name + "`: " + argument.Description);
                                }
                                else
                                {
                                    argList.Add("`<" + argument.Name + ">: " + argument.Type.Name + "`: No description Provided");
                                }
                            }
                            embed.AddField("Argument", String.Join("\n", argList), false);
                        }
                    }
                    else{
                        embed.Title = "No Command Found";
                        embed.Description = "The Command that u provided is not exist, try use `?help` \n to see available commands";
                        embed.Color = DiscordColor.Gold;
                    }
                    embed.Build();

                }


                await ct.RespondAsync(embed: embed);
            }
            catch (Exception e)
            {
                await ct.RespondAsync(e.Message);
            }
        }

    }
}
