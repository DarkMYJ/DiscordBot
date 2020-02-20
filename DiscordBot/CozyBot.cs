using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class CozyBot
    {
        public DiscordClient client { get; private set; }
        public CommandsNextExtension commandsNext { get; private set; }

        public async Task StartBot()
        {
            var config = new DiscordConfiguration
            {
                AutoReconnect = true,
                
            };

            var commandConfig = new CommandsNextConfiguration
            {
                CaseSensitive = false,
                EnableDms = false,
                EnableMentionPrefix = true,
                
            };
            
            client = new DiscordClient(config);
            client.Ready += OnClientReady;

            commandsNext = client.UseCommandsNext(commandConfig);

            await client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return null;
        }
    }
}
