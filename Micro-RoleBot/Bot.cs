using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace Micro_RoleBot
{
    internal class Bot
    {
        public DiscordClient Client;
        private CommandsNextExtension _commands;

        public Bot(Config config)
        {
            var clientConfiguration = new DiscordConfiguration
            {
                Token = config.GetToken(),
                TokenType = TokenType.Bot,
                
                AutoReconnect = true,
                Intents = DiscordIntents.GuildMessages 
                    | DiscordIntents.GuildMessageReactions,
                MinimumLogLevel = LogLevel.Information,
            };

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new[] {config.GetCommandPrefix()},
                EnableDms = true,
                EnableMentionPrefix = true,
            };
            
            Client = new DiscordClient(clientConfiguration);
            _commands = Client.UseCommandsNext(commandsConfig);
        }
    }
}
