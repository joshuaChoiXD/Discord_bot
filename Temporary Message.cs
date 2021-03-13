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
    bool isTem = false;
    int secToDelete = 2;
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
            await _client.SetGameAsync("a game");
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
         if (message.Author.Id == _client.CurrentUser.Id){
                return;
         }
         if(isTem){
                await Task.Delay(secToDelete);
                await message.DeleteAsync();
         }
            if(message.Content == ";tem" && !isTem)
            {
            isTem = true;
            await message.Channel.SendMessageAsync("Temporary Message Mode on.");
            }
            else if(message.Content == ";tem" && isTem){
            isTem = false;
            await message.Channel.SendMessageAsync("Temporary Message Mode off.");
            }
            else if(message.Content.Contains(";tem sec")){
            secToDelete = Convert.ToInt32(message.Content.Substring(8)) * 1000;
            }
        }
    }
}
//Run this code. Enter ;tem to turn on the Temporary Message. Enter it again to turn off. Enter ;tem sec 2 to delete the message after 2 seconds.
//Delete message doesn't work in DM.
//
