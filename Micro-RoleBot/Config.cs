using System.Collections.Generic;
using DSharpPlus.Entities;

namespace Micro_RoleBot
{
    class Config
    {
        private readonly string Token;
        private readonly string CommandPrefix;
        private 

        public Config(string token, string commandPrefix)
        {
            Token = token;
            CommandPrefix = commandPrefix;
            RolesToWatch = new Dictionary<DiscordRole, DiscordEmoji>();
        }

        public string GetToken()
        {
            return Token;
        }

        public string GetCommandPrefix()
        {
            return CommandPrefix;
        }

        public int AddRoleToWatch(DiscordRole discordRole, DiscordEmoji discordEmoji)
        {
            if (RolesToWatch.ContainsKey(discordRole))
            {
                return -1;
            }

            RolesToWatch.Add(discordRole, discordEmoji);
            return 0;
        }
    }
}
