using System;

namespace DiscordBot
{
    class Entrance
    {
        static void Main(string[] args)
        {
            CozyBot cozyBot = new CozyBot();
            cozyBot.StartBot().GetAwaiter().GetResult();
        }
    }
}
