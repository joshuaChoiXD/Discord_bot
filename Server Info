using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Globalization;
using System.Linq;
using Discord.API;
using Discord.Webhook;
using Discord.Net;
using Discord.Rest;
//lol if you find this too many, please forgive me because this code is orginally from my own bot.
//How to support Discord on Viusal Studio: Solution Explorer > Dependencies(Right-Click) > Manage NuGet Packages > (Search Discord) > Download all Purple Label, Released by Rogue Exception or Discord.Net Contributors >
// > Paste this code.
namespace Discord_Bot
{
    class Program
    {
        private DiscordSocketClient _client;
        public static void Main(string[] args)
                  => new Program().MainAsync().GetAwaiter().GetResult();
        static void MainDiscord(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }
        private Task Log(LogMessage m)
        {
            Console.WriteLine(m.ToString());
            return Task.CompletedTask;
        }
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.Ready += ReadyAsync;
            _client.Log += Log;
            _client.MessageReceived += MessageReceivedAsync;
            Console.Title = "Discord Bot";
            var token = "";
            //Insert your own bot token in the var token.
            //Bot Token is literally the Password to your bot, so keep it safe.
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
        private Task ReadyAsync()
        {
            Console.WriteLine("Connected!");
            return Task.CompletedTask;
        }
        private async Task MessageReceivedAsync(SocketMessage message)
        {
                    var chnl = message.Channel as SocketGuildChannel;
                    var Guild = chnl.Guild.Name;
                    var id = chnl.Guild.Id;
                    var owner = chnl.Guild.Owner.Username;
                    var user = chnl.Guild.Users;
                    var user2 = user.Count();
                    var text = chnl.Guild.TextChannels.Count;
                    var voice = chnl.Guild.VoiceChannels.Count;
                    var icon = chnl.Guild.IconUrl;
                    var description = chnl.Guild.Description;
                    if(message.Content == ";server"){
                    await message.Channel.SendMessageAsync("Server Info:");
                    await message.Channel.SendMessageAsync("Server Name:", "Server " + Guild, true);
                    await message.Channel.SendMessageAsync("Server ID:", "ID " + id, true);
                    await message.Channel.SendMessageAsync("Server Description:", "Description is " + description, true);
                    await message.Channel.SendMessageAsync("Owner:", "Owner " + owner, true);
                    await message.Channel.SendMessageAsync("Total Server People and Bots Count:", "Total Number " + user2, true);
                    await message.Channel.SendMessageAsync("Total Text Chanel Count:", "Total Text Channel Number " + text, true);
                    await message.Channel.SendMessageAsync("Total Voice Channel Count:", "Total Voice Channel Number " +voice, true);
                }
        }
    }
}
//Enter ;server and expect the bot to reply.
//
