using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestingBotDiscord.Module
{
    public class InfoModule: ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        [Summary("Echos a message.")]
        public async Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
        {
            // ReplyAsync is a method on ModuleBase
            await ReplyAsync(echo);
        }

        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinChannel(IVoiceChannel channel = null)
        {
            channel = channel ?? (Context.Message.Author as IGuildUser)?.VoiceChannel;
            if (channel is null)
            {
                await Context.Channel.SendMessageAsync("User must be in a voice channel");
                return;
            }

            var audioClient = await channel.ConnectAsync();
        }
    }
}
