using System;
using System.IO;
using System.Threading.Tasks;

namespace Micro_RoleBot
{
    class Program
    {
        private const string configPath = "config.json";
        static void Main(string[] args)
        {
            if (File.Exists(configPath))
            {
                // A configuration file exists
                // check if the file is valid
                // if it is valid, adapt data from the config file
            }
            String discordToken = Environment.GetEnvironmentVariable("DiscordToken");
            String commandPrefix = Environment.GetEnvironmentVariable("CommandPrefix");

            MainAsync(discordToken, commandPrefix).GetAwaiter().GetResult();
        }

        static async Task MainAsync(String discordToken, String commandPrefix)
        {
            
        }
    }
}
