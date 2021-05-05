using System;
using DSharpPlus.Entities;

namespace Micro_RoleBot
{
    class RoleWatch
    {
        private ulong _guild;
        private ulong _channel;
        private ulong _message;
        private ulong _emoji;
        private ulong _role;

        private DiscordGuild GetGuild(Bot api)
        {
            throw new NotImplementedException();
        }

        private DiscordChannel GetChannel(Bot api)
        {
            throw new NotImplementedException();
        }

        private DiscordEmoji GetEmoji(Bot api)
        {
            throw new NotImplementedException();
        }

        private DiscordRole GetRole(Bot api)
        {
            throw new NotImplementedException();
        }

        private void SetRole(SnowflakeObject role) => _role = role.Id;

        private void SetEmoji(SnowflakeObject emoji) => _emoji = emoji.Id;

        private void SetMessage(SnowflakeObject message) => _message = message.Id;

        private void SetChannel(SnowflakeObject channel) => _channel = channel.Id;

        private void SetGuild(SnowflakeObject guild) => _guild = guild.Id;

        public RoleWatch(ulong guild, ulong channel, ulong message, ulong emoji, ulong role)
        {
            _guild = guild;
            _channel = channel;
            _message = message;
            _emoji = emoji;
            _role = role;
        }
    }
}
