using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            var json = string.Empty;
            using (var file = File.OpenRead("config.json"))
            {
                using (var reader = new StreamReader(file, new UTF8Encoding(false)))
                {
                    json = await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            var configJson = JsonConvert.DeserializeObject<Config>(json);

            var config = new DiscordConfiguration
            {
                AutoReconnect = true,
                TokenType = TokenType.Bot,
                Token = configJson.Token,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            var commandConfig = new CommandsNextConfiguration
            {
                CaseSensitive = false,
                EnableDms = false,
                EnableMentionPrefix = true,
                StringPrefixes = new string[] {configJson.Prefix}
            };

            client = new DiscordClient(config);
            client.Ready += OnClientReady;

            commandsNext = client.UseCommandsNext(commandConfig);

            await client.ConnectAsync();
            ConnectDatabase();
            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

        private void ConnectDatabase()
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }
    }
}
