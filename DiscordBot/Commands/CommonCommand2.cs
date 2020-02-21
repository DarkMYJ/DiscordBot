using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class CommonCommand2 : BaseCommandModule
    {
        [Command("clear")]
        [Description("Clear Bot Message")]
        public async Task ClearMessage(CommandContext ct)
        {
            DiscordMember bot = await ct.Guild.GetMemberAsync(677705551555198986);
            DiscordMessage currMessage = ct.Message;
            IReadOnlyList<DiscordMessage> messages = await ct.Channel.GetMessagesBeforeAsync(currMessage.Id,1000);
            await ct.Channel.DeleteMessagesAsync(messages);
            
        }
    }
}
