using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot
{
    public struct Config
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
        [JsonProperty("hostname")]
        public string Host { get; private set; }
        [JsonProperty("port")]
        public int Port { get; private set; }
        [JsonProperty("database")]
        public string Database { get; private set; }
        [JsonProperty("username")]
        public string Username { get; private set; }
        [JsonProperty("password")]
        public string Password { get; private set; }

    }
}
