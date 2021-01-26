//1. This code is for guessing number.
//2. Since this code doesn't use a lot of prefix and substrings, i changed the prefix to ]
//3. I made my own random Algorithm, feel free to ask me in the comments for it. Im going to use C# built-in random.
//4. I provided a help page in case someone really copy this whole code.
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
namespace Discord_Bot
{
    class Program
    {
    bool guess = true;
    int limit = 0;
    int num = 0;
    string people = "";
    int times = 0;//Optional
    Random r = new Random();
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
        if(message.Content == "]help"){
        await message.Channel.SendMessageAsync("`]help` - Help Message\n`]guess` - Start a guess.\n`]cancel` - Cancel a guess");
        }
        else if(!guess && message.Content != "]cancel"){
        int ans = 0;
        //Maybe others have different ways to get the user's guess. But I prefer using try and catch.
        try{
        ans = Convert.ToInt32(message.Content);
        }
        catch(FormatException){
        return;
        }
        if(ans == num){
        times++;
        //We put this infront of send message because it will not count times + 1(which is this try).
        await message.Channel.SendMessageAsync($"Correct :) You took {times} to guess this number!");
        guess = true;
        }
        else{
        await message.Channel.SendMessageAsync("Not correct :(");
        times++;
        }
        }
        else if(message.Content == "]guess" && guess){
        limit = r.Next(100, 500);
        num = r.Next(1, limit);
        await message.Channel.SendMessageAsync($"Guess the Number starts now! Limit: {limit}");
        people = message.Author.Id;
        //I prefer using message.Author.Id since the id is unique. But the message.Author isn't unique.
        guess = false;
        }
        else if(message.Content == "]cancel" && !guess && message.Author.Id == people){
        await message.Channel.SendMessageAsync("Guess the Number cancelled.");
        guess = true;
        }
        else if(message.Content == "]cancel" && !guess && message.Author.Id != people){
        await message.Channel.SendMessageAsync("You cannot cancel the guess");
        }
        else if(message.Content == "]cancel" && guess){
        await message.Channel.SendMessageAsync("Guess the Number doesn't exist");
        }

     }
    }
}
//Overview of this code:
//There a help page: ]help
//Start guess a number by entering ]guess
//End the guess by entering ]cancel
//After entering ]guess, just enter number.
//There is also a code to handle when someone tries to cancel the guess while it doesn't exist.
//It also handles trying to start guess the number without typing ]cancel.
//Only who started the guess can cancel it to prevent some annoying people cancelling it.
//
