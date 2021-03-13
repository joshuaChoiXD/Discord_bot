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
            if(message.Content == ";name){
            var name = message.Author;
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.Blue);
                builder.WithTitle($"You are {name}");
                builder.WithAuthor(name);
                builder.WithDescription($"Your name is {name}");
                builder.AddField("Name:", $"{name}.", true);
                builder.AddField("ID:", $"{message.Author.Id}.", true);
                builder.WithFooter($"Your name is {name}");
                await message.Channel.SendMessageAsync("", false, builder.Build());
                await message.Channel.SendMessageAsync("`This is a html text`");
                //To make a text to html text, it is on your top right keyboard.
                //Below Escape, along with ~.
                }
        }
    }
}
//Run this code. Enter ;name. Expect your bot to reply you with 1 Embed Message and 1 HTML message
//
