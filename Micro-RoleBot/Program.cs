using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
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
            if (!File.Exists(ConfigPath))
            {
                Console.WriteLine("Config file not found. Starting setup process");
                Console.Write("Please enter the Discord API Token from the Developer Portal: ");
                var token = Console.ReadLine()?.Trim();

                var clientConfig = new DiscordConfiguration
                {
                    Token = token,
                    TokenType = TokenType.Bot,
                };

                try
                {
                    var tempBot = new DiscordClient(clientConfig);
                }
                catch (Exception)
                {
                    Console.WriteLine("It seems your API token is invalid, Terminating Setup");
                    Environment.Exit(-1);
                }

                Console.WriteLine("What do you want the command prefix to be?");
                var tempPrefix = Console.ReadLine()?.Trim();

                config = new Config(token, new List<string> {tempPrefix});
            }
            else
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
                        config = new Config(discordToken, new List<string> {commandPrefix});
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
            Bot.InitializeBot(config);
            await Bot.Client.ConnectAsync();
            
            await Task.Delay(-1);
        }
    }
}
