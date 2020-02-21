using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Model
{
    public class Player
    {
        public string Name { get; set; }
        public ulong ID { get; set; }
        public long Balance { get; set; }
    }
}
