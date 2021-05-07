using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Micro_RoleBot
{
    class Program
    {
        // config only contains Discord token and command prefix
        private const string ConfigPath = "config.json";
        // Database contains all the guilds, channels and roles we're watching
        private const string DatabasePath = "reaction-roles.db";
        // Log
        private const string LogFile = "log.txt";

        private static void Main(string[] args)
        {
            Config config = null;
            
            if (File.Exists(ConfigPath))
            {
                using (var reader = new StreamReader(ConfigPath))
                    config = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());

                if (config != null && string.IsNullOrEmpty(config.GetToken()))
                {
                    // Configuration file exists but is not valid
                    // probably just exit and tell that to the user
                    Console.WriteLine("Configuration file found, but not valid. Using Environment Values");
                    
                    var discordToken = Environment.GetEnvironmentVariable("DiscordToken");
                    var commandPrefix = Environment.GetEnvironmentVariable("CommandPrefix");
                    
                    try
                    {
                        config = new Config(discordToken, commandPrefix);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        Environment.Exit(0);
                    }
                    
                }
            }

            MainAsync(config).GetAwaiter().GetResult();
        }

        static async Task MainAsync(Config config)
        {
            var Bot = new Bot(config);
        }
    }
}
