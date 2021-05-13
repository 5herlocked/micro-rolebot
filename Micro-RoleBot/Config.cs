using System.Collections.Generic;
using DSharpPlus;
using DSharpPlus.Entities;

namespace Micro_RoleBot
{
    internal class Config
    {
        private readonly string Token;
        private List<string> CommandPrefix;
        private HashSet<RoleWatch> RolesToWatch;

        public Config(string token, List<string> commandPrefix)
        {
            Token = token;
            CommandPrefix = commandPrefix;
            RolesToWatch = new HashSet<RoleWatch>();
        }

        public string GetToken()
        {
            return Token;
        }

        public List<string> GetCommandPrefix()
        {
            return CommandPrefix;
        }

        public bool AddRoleToWatch(RoleWatch roleToAdd)
        {
            // Add already detects collisions
            return RolesToWatch.Add(roleToAdd);
        }

        public bool StopWatchingRole(RoleWatch roleToRemove)
        {
            // Remove checks for non-existent elements
            return RolesToWatch.Remove(roleToRemove);
        }
    }
}
