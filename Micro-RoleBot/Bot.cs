using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using Micro_RoleBot.Commands;
using Microsoft.Extensions.Logging;

namespace Micro_RoleBot
{
    internal static class Bot
    {
        public static DiscordClient Client;
        private static CommandsNextExtension _commands;
        public static DataAccessHelper DbAccess;

        public static void InitializeBot(Config config)
        {
            var clientConfiguration = new DiscordConfiguration
            {
                Token = config.GetToken(),
                TokenType = TokenType.Bot,
                
                AutoReconnect = true,
                Intents = DiscordIntents.AllUnprivileged,
                MinimumLogLevel = LogLevel.Information,
            };

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = config.GetCommandPrefix(),
                EnableDms = true,
                EnableMentionPrefix = true,
            };

            var interactivityConfig = new InteractivityConfiguration
            {
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(30),
            };
            
            Client = new DiscordClient(clientConfiguration);
            Client.UseInteractivity(interactivityConfig);
            _commands = Client.UseCommandsNext(commandsConfig);
            
            _commands.RegisterCommands<RoleBotCommandModule>();

            DbAccess = new DataAccessHelper("database.db");
        }
        
    }
}
