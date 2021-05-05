using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Logging;

namespace Micro_RoleBot
{
    internal class Bot
    {
        private DiscordClient _client;
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
            
            _client = new DiscordClient(clientConfiguration);
            _commands = _client.UseCommandsNext(commandsConfig);
        }
    }
}
