using DSharpPlus.Entities;
using Microsoft.EntityFrameworkCore;

namespace Micro_RoleBot
{
    public class ReactionRoleContext : DbContext
    {
        public DbSet<DiscordRole> Roles { get; set; }
        public DbSet<DiscordGuild> Guilds { get; set; }
        public DbSet<DiscordMessage> Messages { get; set; }
        public DbSet<DiscordEmoji> Emojis { get; set; }
        
        public DbSet<ReactionRole> ReactionRoles { get; set; }
    }
}