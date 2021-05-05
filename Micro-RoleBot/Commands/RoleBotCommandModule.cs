using System;
using System.Threading.Tasks;

using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Micro_RoleBot.Commands
{
    [RequirePermissions(DSharpPlus.Permissions.ManageRoles)]
    class RoleBotCommandModule : BaseCommandModule
    {
        [Command("addRole"), Description("Constructs a new Role watcher")]
        [RequirePermissions(DSharpPlus.Permissions.ManageRoles)]
        public async Task AddRoleToWatch(CommandContext ctx,
            [Description("Channel to watch")] DiscordChannel channel,
            [Description("Message to watch")] string messageId,
            [Description("Emoji to watch")] DiscordEmoji emoji,
            [Description("Role to watch")] DiscordRole role)
        {

        }

        [Command("removeRole"), Description("Removes a pre-existing Role watcher")]
        [RequirePermissions(DSharpPlus.Permissions.ManageRoles)]
        public async Task RemoveRoleToWatch(CommandContext ctx, 
            [Description("The Role to stop watching")] DiscordRole role)
        {
            // **FIND THE CORRECT ROLEWATCH OBJECT FROM CURRENT CONFIG**
            // Then remove said object
        }
    }
}
