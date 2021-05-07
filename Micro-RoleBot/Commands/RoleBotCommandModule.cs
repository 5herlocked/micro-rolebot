using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

namespace Micro_RoleBot.Commands
{
    [RequirePermissions(Permissions.ManageRoles)]
    class RoleBotCommandModule : BaseCommandModule
    {
        [Command("setup"), Aliases("make")]
        [Description("Starts an interactive session that walks you through reaction roles")]
        [RequireUserPermissions(Permissions.ManageRoles)]
        public async Task InteractiveReactionRole(CommandContext ctx)
        {
            await ctx.RespondAsync("Henlo. Which channel would you like the message to be in?");

            var channelResponse = (await ctx.Message.GetNextMessageAsync()).Result;

            var mentionedChannelsCount = channelResponse.MentionedChannels.Count;
            
            if (mentionedChannelsCount != 1)
            {
                switch (mentionedChannelsCount)
                {
                    case 0:
                        await ctx.RespondAsync("Please enter the channel you want the message to be in");
                        break;
                    case > 1:
                        await ctx.RespondAsync("You've entered too many channels");
                        break;
                    case < 0:
                        await ctx.RespondAsync(
                            "You've entered fewer than zero channels. I don't know what you're thinking");
                        break;
                    default:
                        await ctx.RespondAsync("You've managed to break everything. I suggest you try again");
                        return;
                }
            }

            var chosenChannel = channelResponse.MentionedChannels[0];

            await ctx.RespondAsync("Alright the channel is <#" + chosenChannel.Id + ">. " +
                                   "What would you like the message to say? Use a `|` to separate the title " +
                                   "from the description ");
            
            // TODO: Exception Handling

            var messageResponse = (await ctx.Message.GetNextMessageAsync()).Result;

            var messageContents = messageResponse.Content.Split('|', StringSplitOptions.TrimEntries);

            await ctx.RespondAsync("Alright I got a title and a description. This is how the message will look.");
            var embedBuilder = new DiscordEmbedBuilder
            {
                Title = messageContents[0],
                Description = messageContents[1]
            };

            await ctx.RespondAsync(embedBuilder);

            await ctx.RespondAsync("Next up, we're going to add roles. The format for adding roles is the " +
                                   "emoji then a mention of the role.\nExample: ```:cry: @Depression```");
            var rolesBeingWatched = new List<RoleWatch>();
            
            while (true)
            {
                var roleMessage = (await ctx.Message.GetNextMessageAsync()).Result;
                if (roleMessage.Content.ToLower() == "done")
                {
                    break;
                }
                // TODO: Exception handling
                var mentionedRole = roleMessage.MentionedRoles;
                var usedEmoji = DiscordEmoji.FromName(ctx.Client, roleMessage.Content.Split()[0]);

                var constructedRole = new RoleWatch(ctx.Guild, chosenChannel, mentionedRole[0], usedEmoji.Name);
                
                rolesBeingWatched.Add(constructedRole);
            }

            var createdMessage = await ctx.Client.SendMessageAsync(chosenChannel, embedBuilder);
            foreach (var role in rolesBeingWatched)
            {
                role.Message = createdMessage.Id;
                await createdMessage.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, role.Emoji));
            }
            
            // ADD ALL WATCHED ROLES TO DATA STORE
            DataAccessHelper.AddRoleWatchList(rolesBeingWatched);
        }
    }
}
