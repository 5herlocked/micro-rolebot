using System;
using DSharpPlus.Entities;
using SQLite;

namespace Micro_RoleBot
{
    [Table("rolewatch")]
    public class RoleWatch
    {
        [PrimaryKey] [Column("id")] 
        public Guid Id { get; private set; }
        
        [Column("guild")]
        public ulong Guild { get; private set; }
        
        [Column("channel")]
        public ulong Channel { get; private set; }
        
        [Column("message")]
        public ulong Message { get; set; }
        
        [Column("role")]
        public ulong Role { get; private set; }
        
        [Column("emoji")]
        public string Emoji { get; private set; }

        public RoleWatch(DiscordGuild guild, DiscordChannel channel, DiscordMessage message, DiscordRole role, DiscordEmoji emoji)
        {
            Id = new Guid();
            Guild = guild.Id;
            Channel = channel.Id;
            Message = message.Id;
            Role = role.Id;
            Emoji = emoji.Name;
        }

        public RoleWatch(DiscordGuild guild, DiscordChannel channel, DiscordRole role, string emoji)
        {
            Id = new Guid();
            Guild = guild.Id;
            Channel = channel.Id;
            Role = role.Id;
            Emoji = emoji;
        }
    }
}
