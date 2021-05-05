using System;

using DSharpPlus.Entities;

namespace Micro_RoleBot
{
    class RoleWatch
    {
        private ulong Guild;
        private ulong Channel;
        private ulong Message;
        private string Emoji;
        private ulong Role;

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

        private void SetRole(DiscordRole role)
        {
            throw new NotImplementedException();
        }

        private void SetEmoji(DiscordEmoji emoji)
        {
            throw new NotImplementedException();
        }

        private void SetMessage(object result)
        {
            throw new NotImplementedException();
        }

        private void SetChannel(DiscordChannel channel)
        {
            throw new NotImplementedException();
        }

        private void SetGuild(DiscordGuild guild)
        {
            throw new NotImplementedException();
        }

        public RoleWatch(ulong guild, ulong channel, ulong message, string emoji, ulong role)
        {
            Guild = guild;
            Channel = channel;
            Message = message;
            Emoji = emoji;
            Role = role;
        }
    }
}
