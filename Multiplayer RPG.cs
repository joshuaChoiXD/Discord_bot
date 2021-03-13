//1. Hi everyone im Axehunter. So this multiplayer rpg is coded by me and probably has a lots of bug(But as far as I know, i fixed them all).
//2. Feel free to add new fighters into the game and make some balance change.
//3. Also, if there are missing some variables, please add them yourself cuz i got too many variables -_-
//4. im Axehunter, so normally my prefix and the name of this game starts with axe. If you want to change it, please remember to change 
//something like substring.
//5. By the way, there are lots of unnecessary code since I gave up some fighters to make. But well, Im not sure will deleting those unnecessary code
//still make the code error-free. So I decided to keep them.

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
     bool fighter = false;
        bool defence = false;
        bool healer = false;
        bool spike = false;
        bool normalPerson = true;
        bool judge = false;
        bool judge1 = false;
        bool fighter1 = false;
        bool defence1 = false;
        bool healer1 = false;
        bool normalPerson1 = true;
        bool spike1 = false;
        bool judge2 = false;
        bool spike2 = false;
        bool fighter2 = false;
        bool defence2 = false;
        bool healer2 = false;
        bool error1 = false;
        bool error2 = false;
        bool snipe1 = false;
        bool snipe2 = false;
        bool snipe = false;
        bool ejudge = false;
        bool esniper = false;
        bool normalPerson2 = true;
        bool enterBattle = false;
        bool fire = false;
        bool efire = false;
        bool fire1 = false;
        bool fire2 = false;
        bool error = false;
        bool sheriff = false;
        bool esheriff = false;
        bool sheriff1 = false;
        bool sheriff2 = false;
        bool eError = false;
        bool efighter = false;
        bool edefence = false;
        bool ehealer = false;
        bool enormal = true;
        bool espike = false;
        int health = 50;
        int eHealth = 50;
        int health1 = 60;
        int health2 = 60;
        int defenceP = 0;
        bool toDefence = false;
        bool eToDefence = false;
        bool toDefence1 = false;
        bool toDefence2 = false;
        bool defenceP1 = false;
        bool defenceP2 = false;
        bool yourTurn = true;
        bool ended = false;
        string people = "";
        bool start = true;
        string battleReady1 = null;
        string battleReady2 = null;
        string battleReadya1 = null;
        string battleReadya2 = null;
        bool battlestart = false;
        bool pvpMenu = true;
        bool p1F = false;
        bool p2F = false;
        bool player1turn = true;
        bool player2turn = false;
        int showD = 0;
                bool tbounty1 = false;
        bool tbounty2 = false;
                bool bounty1 = false;
        bool bounty2 = false;
        bool a = true;
        float p1fire = 1;
        float p2fire = 1;
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
        var contain = message.Content;
            if (contain == ";battle" && !battle)
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.Teal);
                people = message.Author.Id.ToString();
                start = false;
                bounty = false;
                tbounty = false;
                builder.WithTitle("Axe Battle Guide");
                builder.WithDescription("The Axe Battle is a mini battle game that you can fight against a bot or your friends");
                builder.AddField("Fighter List:", "1 - Axe(Damage + 2)\n2 - Shield(Defence% + 30%)\n3 - Healer(Heal + 1)\n4 - Error Computer(Deal damage from 0 to 7 randomly)\n5 - Sniper(Damage + 3. Health - 20)\n6 - Metal Giant(Health + 20. Damage - 1)\n7 - Fire Boy(First 5 round damage + 1, then Each 10 round damage + 1. Base damage 1.)\n8 - Spikey Shield(Defence + 15%. Each time defence able and enemy hit, enemy will experience 1 Health Damage.)\n9 - Judge(When he is half health, he puts the Ring of Law on the enemy.)\n(Ring of Law: Each time enemy succesfully attacks, the enemy himself will absorb 50% of his damage.Round down to the nearest integer.)\n(When over half health, the Ring of Law will be removed until next time he reached half health)\n10 - Normal Person(No effects)", true);
                //I know the names are lame.. But im not known for making creative ideas.
                builder.AddField("Move List: ", "a - Attack\nd - Defence next round.(Normally 20% to successfully defence)\nh - Heal 2 Health", true);
                builder.AddField("PvP Step 1:", "Enter `;axe battle ready` to ready up and pair with others", true);
                builder.AddField("PvP Step 2:", "Enter `;axe battleF 1 = {fighter no.}` or `;axe battleF 2 = {fighter no.}` to choose your fighter", true);
                builder.AddField("PvP Step 3:", "Player 1 starts first. Enter `;axe pbattle 1 = {Move no.}` for Player 1 to do a move.\n`;axe pbattle 2 = {Move no.}` for Player 2 to do a move", true);
                builder.AddField("PvP Step 4:", "Fight and show who is the true winner!", true);
                await message.Channel.SendMessageAsync("", false, builder.Build());
            }
            else if(contain == ";axe battle ready cancel" && !p1F || contain == ";axe battle ready cancel" && !p2F)
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.LightOrange);
                builder.WithTitle("Matchmaking cancelled :(");
                if (battleReadya2 != null)
                {
                    builder.AddField("Matchmake People", "Player 1: " + battleReadya1 + "\nPlayer 2: " + battleReadya2, true);
                }
                else
                {
                    builder.AddField("Matchmake People", "Player 1: " + battleReadya1, true);
                }
                await message.Channel.SendMessageAsync("", false, builder.Build());
                battleReadya2 = null;
                battleReadya1 = null;
                battleReady1 = null;
                battleReady2 = null;
                p1F = true;
                p2F = true;
                a = false;
                pvpMenu = true;
            }
            else if (contain == ";axe battle ready" && pvpMenu)
            {
                if (battleReady1 == null)
                {
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.DarkGreen);
                    battleReady1 = message.Author.Id.ToString();
                    battleReadya1 = message.Author.ToString();
                    builder.WithTitle("Player 1 is ready!");
                    builder.WithDescription("Enter `;axe battle ready cancel` to leave matchmaking");
                    builder.WithAuthor(message.Author);
                    await message.Channel.SendMessageAsync("", false, builder.Build());
                    p1F = false;
                }
                else if (battleReady1 != null && battleReady2 == null)
                {
                    if (message.Author.Id.ToString() != battleReady1)
                    {
                        battleReady2 = message.Author.Id.ToString();
                        battlestart = true;
                        p2F = false;
                        a = true;
                        tbounty1 = false;
                        tbounty2 = false;
                        bounty1 = false;
                        bounty2 = false;
                        EmbedBuilder builder = new EmbedBuilder();
                        builder.WithColor(Color.Green);
                        battleReadya2 = message.Author.ToString();
                        builder.WithTitle("Player 2 is ready!");
                        builder.WithDescription("Enter any key to continue..");
                        builder.WithAuthor(message.Author);
                        await message.Channel.SendMessageAsync("", false, builder.Build());
                    }
                    else
                    {
                        await message.Channel.SendMessageAsync("Please find a partner \nor you type `;axe battle` and play against a bot.");
                    }
                }
                else
                {
                    if (message.Author.Id.ToString() != battleReady1 || message.Author.Id.ToString() != battleReady2)
                    {
                        await message.Channel.SendMessageAsync("Please wait a while until others finished playing");
                    }
                }
            }
            else if (battlestart && pvpMenu)
            {
                pvpMenu = false;
                await message.Channel.SendMessageAsync("Please Player 1(The one who ready first) type `;axe battleF 1 = {Fighter No.}`");
                await message.Channel.SendMessageAsync("Please Player 2(The one who ready later) type `;axe battleF 2 = {Fighter No.}`");
            }
            else if (contain.Contains(";axe battleF 1 =") && !p1F)
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.DarkBlue);
                int fightera = 0;
                p1fire = 1;
                if (message.Author.Id.ToString() == battleReady1)
                {
                    try
                    {
                        fightera = Convert.ToInt32(contain.Substring(17));
                    }
                    catch (FormatException)
                    {
                        
                        builder.WithDescription("Please enter a number or an integer!");
                    }
                    catch (OverflowException)
                    {
                        builder.WithDescription("Enter a proper option >_<");
                    }
                    if (fightera == 1)
                    {
                        fighter1 = true;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = false;
                        metal1 = false;
                        fire1 = false;
                        spike1 = false;
                        judge1 = false;
                        sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Axe.");
                        
                    }
                    else if (fightera == 2)
                    {
                        fighter1 = false;
                        defence1 = true;
                        healer1 = false;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = false;
                        metal1 = false;
                        spike1 = false;
                        fire1 = false;
                        judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Shield.");
                      
                    }
                    else if (fightera == 3)
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = true;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = false;
                        metal1 = false;
                        spike1 = false;
                        fire1 = false; judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Healer.");
                      
                    }
                    else if (fightera == 4)
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = false;
                        fire1 = false;
                        error1 = true;
                        snipe1 = false;
                        metal1 = false;
                        spike1 = false; judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Error Computer.");
                        
                    }
                    else if (fightera == 5)
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = true;
                        metal1 = false;
                        fire1 = false;
                        health1 = 40;
                        spike1 = false; judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Sniper.");
                       
                    }
                    else if (fightera == 6)
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = false;
                        metal1 = true;
                        fire1 = false;
                        health1 = 80;
                        spike1 = false; judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Metal Giant.");
                       
                    }
                    else if (fightera == 7)
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = false;
                        metal1 = false;
                        fire1 = true;
                        spike1 = false; judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Fire Boy.");
                        

                    }
                    else if (fightera == 8)
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = false;
                        metal1 = false;
                        fire1 = false;
                        spike1 = true; judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Spikey Shield.");
                       
                    }
                    else if (fightera == 9)
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = false;
                        error1 = false;
                        snipe1 = false;
                        metal1 = false;
                        fire1 = false;
                        spike1 = false; judge1 = true; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Judge.");
                     

                    }
                    else
                    {
                        fighter1 = false;
                        defence1 = false;
                        healer1 = false;
                        normalPerson1 = true;
                        error1 = false;
                        snipe1 = false;
                        metal1 = false;
                        fire1 = false;
                        spike1 = false; judge1 = false; sheriff1 = false;
                        builder.WithTitle("Player 1 has chosen Normal Person.");
                    }
                    p1F = true;
                }
                else
                {
                    builder.AddField("Player 1 Choose Fighter Command", "Please Player 1(The on who ready first) type `;axe battleF 1 = {Fighter No.}`", true);
                    builder.AddField("Player 2 Choose Fighter Command","Please Player 2(The one who ready later) type `;axe battleF 2 = {Fighter No.}`", true);
                }
                await message.Channel.SendMessageAsync("", false, builder.Build());
            }
            else if (contain.Contains(";axe battleF 2 =") && !p2F)
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.DarkBlue);
                int fightera = 0;
                p2fire = 1;
                if (message.Author.Id.ToString() == battleReady2)
                {
                    try
                    {
                        fightera = Convert.ToInt32(contain.Substring(17));
                    }
                    catch (FormatException)
                    {
                        builder.WithDescription("Please enter a number or an integer!");
                    }
                    catch (OverflowException)
                    {
                        builder.WithDescription("Enter a proper option >_<");
                    }
                    if (fightera == 1)
                    {
                        fighter2 = true;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = false;
                        snipe2 = false;
                        metal2 = false;
                        spike2 = false;
                        fire2 = false;
                        judge2 = false; 
                        builder.WithTitle("Player 2 has chosen Axe.");
                       
                    }
                    else if (fightera == 2)
                    {
                        fighter2 = false;
                        defence = true;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = false;
                        snipe2 = false;
                        fire2 = false;
                        metal2 = false;
                        spike2 = false;
                        judge2 = false; 
                        builder.WithTitle("Player 2 has chosen Shield.");
                      
                    }
                    else if (fightera == 3)
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = true;
                        normalPerson2 = false;
                        error2 = false;
                        snipe2 = false;
                        metal2 = false;
                        fire2 = false;
                        spike2 = false;
                        judge2 = false; sheriff2 = false;
                        builder.WithTitle("Player 2 has chosen Healer.");
                       
                    }
                    else if (fightera == 4)
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = true;
                        metal2 = false;
                        snipe2 = false;
                        spike2 = false;
                        judge2 = false;
                        fire2 = false; sheriff2 = false;
                        builder.WithTitle("Player 2 has chosen Error Computer.");
                      
                    }
                    else if (fightera == 5)
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = false;
                        metal2 = false;
                        snipe2 = true;
                        fire2 = false;
                        health2 = 40;
                        spike2 = false;
                        judge2 = false; sheriff2 = false;
                        builder.WithTitle("Player 2 has chosen Sniper.");
                        b
                    }
                    else if (fightera == 6)
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = false;
                        metal2 = true;
                        snipe2 = false;
                        fire2 = false;
                        health2 = 80;
                        spike2 = false;
                        judge2 = false;
                        builder.WithTitle("Player 2 has chosen Metal Giant.");
                       
                    }
                    else if (fightera == 7)
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = false;
                        metal2 = false;
                        snipe2 = false;
                        fire2 = true;
                        spike2 = false;
                        judge2 = false;
                        builder.WithTitle("Player 2 has chosen Fire Boy.");
                       
                    }
                    else if (fightera == 8)
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = false;
                        metal2 = false;
                        snipe2 = false;
                        fire2 = false;
                        spike2 = true;
                        judge2 = false;
                        builder.WithTitle("Player 2 has chosen Spikey Shield");
                       

                    }
                    else if (fightera == 9)
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = false;
                        error2 = false;
                        metal2 = false;
                        snipe2 = false;
                        fire2 = false;
                        spike2 = false;
                        judge2 = true;
                        builder.WithTitle("Player 2 has chosen Judge.");
                        
                    }
                    else
                    {
                        fighter2 = false;
                        defence2 = false;
                        healer2 = false;
                        normalPerson2 = true;
                        error2 = false;
                        snipe2 = false;
                        fire2 = false;
                        metal2 = false;
                        spike2 = false;
                        judge2 = false;
                        builder.WithTitle("Player 2 has chosen Normal Person.");
                    }
                    p2F = true;
                }
                else
                {
                    builder.AddField("Player 1 Choose Fighter Command", "Please Player 1(The on who ready first) type `;axe battleF 1 = {Fighter No.}`", true);
                    builder.AddField("Player 2 Choose Fighter Command", "Please Player 2(The one who ready later) type `;axe battleF 2 = {Fighter No.}`", true);
                }
                await message.Channel.SendMessageAsync("", false, builder.Build());
            }
            else if (p1F && p2F && a)
            {
                EmbedBuilder builder = new EmbedBuilder();
                builder.WithColor(Color.DarkBlue);
                  builder.AddField("Player 1 Turn.", "Player 1 please enter `;axe pbattle 1 = {move no.}`", true);
                a = false;
                player1turn = true; await message.Channel.SendMessageAsync("", false, builder.Build());
            }
            else if (contain.Contains(";axe pbattle 1 =") && message.Author.Id.ToString() == battleReady1 && player1turn)
            {
                var move = contain.Substring(17);
                var show = 0;
                if (health1 > 0 && health2 > 0)
                {
                    p1fire += 0.1f;
                    if (move == "a")
                    {
                        if (fighter1)
                        {
                            if (!toDefence2)
                            {
                                health2 -= 4;
                                showD = 4;
                                if (judge2)
                                {
                                    if (health2 <= 30)
                                    {
                                        health1 -= 2;
                                    }
                                }
                            }
                        }
                        else if (fire1)
                        {
                            if (!toDefence2)
                            {
                                health2 -= Convert.ToInt32(p1fire);
                                showD = Convert.ToInt32(p1fire);
                                if (judge2)
                                {
                                    if (health2 <= 30)
                                    {
                                        health1 -= Convert.ToInt32(Math.Floor(p1fire) / 2);
                                    }
                                }
                            }
                        }
                        else if (metal1)
                        {
                            if (!toDefence2)
                            {
                                health2 -= 1;
                                showD = 1;
                            }
                        }
                        else if (snipe1)
                        {
                            if (!toDefence2)
                            {
                                health2 -= 5;
                                showD = 5;
                                if (judge2)
                                {
                                    if (health2 <= 30)
                                    {
                                        health1 -= 2;
                                    }
                                }
                            }
                        }
                        else if (error1)
                        {
                            if (!toDefence2)
                            {

                                defenceP = rnd.Next(1, 75);
                                if (defenceP <= 2)
                                {
                                    health2 -= 0;
                                    showD = 0;
                                    await message.Channel.SendMessageAsync("You dealt no damage with this attack!");
                                }
                                else if (defenceP <= 10 && defenceP > 2)
                                {
                                    health2 -= 1;
                                    showD = 1;
                                }
                                else if (defenceP <= 35 && defenceP > 10)
                                {
                                    health2 -= 2;
                                    showD = 2;
                                    if (judge2)
                                    {
                                        if (health2 <= 30)
                                        {
                                            health1 -= 1;
                                        }
                                    }
                                }
                                else if (defenceP <= 55 && defenceP > 35)
                                {
                                    health2 -= 3;
                                    showD = 3;
                                    if (judge2)
                                    {
                                        if (health2 <= 30)
                                        {
                                            health1 -= 1;
                                        }
                                    }
                                }
                                else if (defenceP <= 65 && defenceP > 55)
                                {
                                    health2 -= 4;
                                    showD = 4;
                                    if (judge2)
                                    {
                                        if (health2 <= 30)
                                        {
                                            health1 -= 2;
                                        }
                                    }
                                }
                                else if (defenceP <= 70 && defenceP > 65)
                                {
                                    health2 -= 5;
                                    showD = 5; if (judge2)
                                    {
                                        if (health2 <= 30)
                                        {
                                            health1 -= 2;
                                        }
                                    }
                                }
                                else if (defenceP <= 73 && defenceP > 70)
                                {
                                    health2 -= 6;
                                    showD = 6; if (judge2)
                                    {
                                        if (health2 <= 30)
                                        {
                                            health1 -= 3;
                                        }
                                    }
                                }
                                else if (defenceP <= 74 && defenceP > 73)
                                {
                                    health2 -= 7;
                                    showD = 7;
                                    if (judge2)
                                    {
                                        if (health2 <= 30)
                                        {
                                            health1 -= 3;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!toDefence2)
                            {
                                health2 -= 2;
                                showD = 2; if (judge2)
                                {
                                    if (health2 <= 30)
                                    {
                                        health1 -= 1;
                                    }
                                }
                            }
                        }
                        if (!toDefence2)
                        {
                            EmbedBuilder builder = new EmbedBuilder();
                            builder.WithColor(Color.DarkBlue);
                            builder.WithTitle($"You successfully dealt {showD} damage!");
                            if (health2 <= 0)
                            {
                                builder.WithDescription("Congrats you for beating Player 2!");
                                battleReadya2 = null;
                                battleReadya1 = null;
                                p1F = false;
                                p2F = false;
                                pvpMenu = true;
                                battleReady1 = null;
                                battleReady2 = null;
                                battlestart = false;
                            }
                            await message.Channel.SendMessageAsync("", false, builder.Build());
                        }
                        else
                        {
                            if (spike2)
                            {
                                health1 -= 1;
                                await message.Channel.SendMessageAsync("Ouch! Player 2's spikey shield hurted you!");
                            }
                            else
                            {
                                await message.Channel.SendMessageAsync("so sad :( Your attack was reflected");
                            }
                        }
                    }
                    else if (move == "d")
                    {
                        if (defence1)
                        {
                            defenceP = rnd.Next(1, 100);
                            if (defenceP <= 50)
                            {
                                toDefence1 = true;
                            }
                            else
                            {
                                toDefence1 = false;
                            }
                        }
                        else if (spike1)
                        {
                            defenceP = rnd.Next(1, 100);
                            if (defenceP <= 35)
                            {
                                toDefence1 = true;
                            }
                            else
                            {
                                toDefence1 = false;
                            }
                        }
                        else
                        {
                            defenceP = rnd.Next(1, 100);
                            if (defenceP <= 20)
                            {
                                toDefence1 = true;
                            }
                            else
                            {
                                toDefence1 = false;
                            }
                        }
                    }
                    else if (move == "h")
                    {
                        if (healer1)
                        {
                            health1 += 3;
                        }
                        else
                        {
                            health1 += 2;
                        }
                        await message.Channel.SendMessageAsync("You healed!");
                    }
                    else
                    {
                        EmbedBuilder buildera = new EmbedBuilder();
                        buildera.WithColor(Color.DarkRed);
                        buildera.WithTitle("You did nothing!");
                        buildera.AddField("Attack:", "Enter `;axe pbattle 1 = a`", true);
                        buildera.AddField("Defence:", "Enter `;axe pbattle 1 = d`.", true);
                        buildera.AddField("Heal:", "Enter `;axe pbattle 1 = h`", true);
                        await message.Channel.SendMessageAsync("", false, buildera.Build());
                    }
                    toDefence2 = false;
                    player2turn = true;
                    player1turn = false;
                    EmbedBuilder builderb = new EmbedBuilder();
                    builderb.WithColor(Color.DarkBlue);
                    if (health1 > 0 && health2 > 0)
                    {
                        builderb.WithTitle("Player 2 Turn.");
                        builderb.WithDescription("Enter `;axe pbattle 2 = {move no.}` to make a move");
                    }
                    else
                    {
                        builderb.WithTitle("One of You is defeated. Enter `;axe battle ready` to play again");
                    }
                    await message.Channel.SendMessageAsync("", false, builderb.Build());
                }
            }
            else if (contain.Contains(";axe pbattle 2 =") && player2turn && message.Author.Id.ToString() == battleReady2)
            {
                var move = contain.Substring(17);
                var show = 0;
                if (health1 > 0 && health2 > 0)
                {
                    p2fire += 0.1f;
                    if (move == "a")
                    {
                        if (fighter2)
                        {
                            if (!toDefence1)
                            {
                                health1 -= 4;
                                show = 4;
                                if (judge1)
                                {
                                    if (health1 <= 30)
                                    {
                                        health2 -= 2;
                                    }
                                }
                            }
                        }
                        else if (fire2)
                        {
                            if (!toDefence2)
                            {
                                health1 -= Convert.ToInt32(p2fire);
                                show = Convert.ToInt32(p2fire);
                                if (judge1)
                                {
                                    if (health1 <= 30)
                                    {
                                        health2 -= Convert.ToInt32(Math.Floor(p2fire));
                                    }
                                }
                            }
                        }
                        else if (metal2)
                        {
                            if (!toDefence1)
                            {
                                health1 -= 1;
                                show = 1;
                            }
                        }
                        else if (snipe2)
                        {
                            if (!toDefence1)
                            {
                                health1 -= 5;
                                show = 5; if (judge1)
                                {
                                    if (health1 <= 30)
                                    {
                                        health2 -= 2;
                                    }
                                }
                            }
                        }
                        else if (error2)
                        {
                            if (!toDefence1)
                            {

                                defenceP = rnd.Next(1, 75);
                                if (defenceP <= 2)
                                {
                                    health1 -= 0;
                                    show = 0;
                                    await message.Channel.SendMessageAsync("You dealt no damage with this attack!");
                                }
                                else if (defenceP <= 10 && defenceP > 2)
                                {
                                    health1 -= 1;
                                    show = 1;
                                }
                                else if (defenceP <= 35 && defenceP > 10)
                                {
                                    health1 -= 2;
                                    show = 2; if (judge1)
                                    {
                                        if (health1 <= 30)
                                        {
                                            health2 -= 1;
                                        }
                                    }
                                }
                                else if (defenceP <= 55 && defenceP > 35)
                                {
                                    health1 -= 3;
                                    show = 3;
                                    if (judge1)
                                    {
                                        if (health1 <= 30)
                                        {
                                            health2 -= 1;
                                        }
                                    }
                                }
                                else if (defenceP <= 65 && defenceP > 55)
                                {
                                    health1 -= 4;
                                    show = 4;
                                    if (judge1)
                                    {
                                        if (health1 <= 30)
                                        {
                                            health2 -= 2;
                                        }
                                    }
                                }
                                else if (defenceP <= 70 && defenceP > 65)
                                {
                                    health1 -= 5;
                                    show = 5;
                                    if (judge1)
                                    {
                                        if (health1 <= 30)
                                        {
                                            health2 -= 2;
                                        }
                                    }
                                }
                                else if (defenceP <= 73 && defenceP > 70)
                                {
                                    health1 -= 6;
                                    show = 6;
                                    if (judge1)
                                    {
                                        if (health1 <= 30)
                                        {
                                            health2 -= 3;
                                        }
                                    }
                                }
                                else if (defenceP <= 74 && defenceP > 73)
                                {
                                    health1 -= 7;
                                    show = 7;
                                    if (judge1)
                                    {
                                        if (health1 <= 30)
                                        {
                                            health2 -= 3;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!toDefence1)
                            {
                                health1 -= 2;
                                show = 2;
                                if (judge1)
                                {
                                    if (health1 <= 30)
                                    {
                                        health2 -= 1;
                                    }
                                }
                            }
                        }
                        if (!toDefence1)
                        {
                            EmbedBuilder buildera = new EmbedBuilder();
                            buildera.WithColor(Color.DarkBlue);
                            buildera.WithTitle($"You successfully dealt {show} damage!");
                            if (health1 <= 0)
                            {
                                buildera.WithDescription("Congrats you for beating Player 1`");
                                battleReadya2 = null;
                                battleReadya1 = null;
                                p1F = false;
                                p2F = false;
                                pvpMenu = true;
                                battleReady1 = null;
                                battleReady2 = null;
                                battlestart = false;
                            }
                            await message.Channel.SendMessageAsync("", false, buildera.Build());
                        }
                        else
                        {
                            EmbedBuilder buildera = new EmbedBuilder();
                            buildera.WithColor(Color.DarkBlue);
                            if (spike1)
                            {
                                buildera.WithTitle("Ouch! Player 1 spikey shield hurted you!");
                                health1 -= 1;
                            }
                            
                            buildera.AddField("so sad :(", "Your attack was reflected!", true);
                            await message.Channel.SendMessageAsync("", false, buildera.Build());
                        }
                    }
                    else if (move == "d")
                    {
                        if (defence2)
                        {
                            defenceP = rnd.Next(1, 100);
                            if (defenceP <= 50)
                            {
                                toDefence2 = true;
                            }
                            else
                            {
                                toDefence2 = false;
                            }
                        }
                        else
                        {
                            defenceP = rnd.Next(1, 100);
                            if (defenceP <= 20)
                            {
                                toDefence2 = true;
                            }
                            else
                            {
                                toDefence2 = false;
                            }
                        }
                    }
                    else if (move == "h")
                    {
                        if (healer2)
                        {
                            health2 += 3;
                        }
                        else
                        {
                            health2 += 2;
                        }
                        await message.Channel.SendMessageAsync("You healed!");
                    }
                    else
                    {
                        EmbedBuilder buildera = new EmbedBuilder();
                        buildera.WithColor(Color.DarkRed);
                        buildera.WithTitle("You did nothing!");
                        buildera.AddField("Attack:", "Enter `;axe pbattle 2 = a`", true);
                        buildera.AddField("Defence:", "Enter `;axe pbattle 2 = d`.", true);
                        buildera.AddField("Heal:", "Enter `;axe pbattle 2 = h`", true);
                        await message.Channel.SendMessageAsync("", false, buildera.Build());
                    }
                    toDefence1 = false;
                    player2turn = false;
                    player1turn = true;
                    EmbedBuilder builder = new EmbedBuilder();
                    builder.WithColor(Color.DarkBlue);
                    builder.AddField("Round Ended!", $"Player 1 Health: {health1}\nPlayer 2 Health: {health2}", true);
                    await message.Channel.SendMessageAsync("", false, builder.Build());
                    p2F = false;
                    p1F = true;
                    EmbedBuilder builderb = new EmbedBuilder();
                    builderb.WithColor(Color.DarkBlue);
                    if (health1 > 0 && health2 > 0)
                    {
                        builderb.WithTitle("Player 1 Turn");
                        builderb.WithDescription("Enter `;axe pbattle 1 = {move no.}` to make a move");
                    }
                    else
                    {
                        builderb.WithTitle("One of You is defeated. Enter `;axe battle ready` to play again");
                    }
                    await message.Channel.SendMessageAsync("", false, builderb.Build());
                }
            }
        }
    }
}
//So here's a short overview of what this code does.
//You enter ;axe battle ready to ready up
//Your friend or whatever enter ;axe battle ready to also ready up.
//Enter ;axe battle ready cancel to cancel Matchmaking.
//Then both of you choose 1 fighter. Player 1(Who ready up first) enter ;axe battleF 1 = {Fighter No.}
//Player 2(Who ready up later) enter ;axe battleF 2 = {Fighter No.}
//Fighter List can be found by typing ;axe battle
//After that, Player 1 starts first. Enter ;axe pbattle 1 = {Move No.}. Player 2 enter ;axe pbattle 2 = {Move No.} To also make a move.
//Last, a round ends. The bot will show current health of both players.
//This bot is not suitable for cross-server fight, since the message of battle end will only show in one side. Feel free to make adjustment
//
