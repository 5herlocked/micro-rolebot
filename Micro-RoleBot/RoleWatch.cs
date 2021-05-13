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
        public string Guild { get; private set; }
        
        [Column("channel")]
        public string Channel { get; private set; }
        
        [Column("message")]
        public string Message { get; set; }
        
        [Column("role")]
        public string Role { get; private set; }
        
        [Column("emoji")]
        public string Emoji { get; private set; }

        public RoleWatch(DiscordGuild guild, DiscordChannel channel, DiscordMessage message, DiscordRole role, DiscordEmoji emoji)
        {
            Id = new Guid();
            Guild = guild.Id.ToString();
            Channel = channel.Id.ToString();
            Message = message.Id.ToString();
            Role = role.Id.ToString();
            Emoji = emoji.Name;
        }

        public RoleWatch(DiscordGuild guild, DiscordChannel channel, DiscordRole role, string emoji)
        {
            Id = new Guid();
            Guild = guild.Id.ToString();
            Channel = channel.Id.ToString();
            Role = role.Id.ToString();
            Emoji = emoji;
        }
    }
}
