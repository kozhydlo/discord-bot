using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Testbot

{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += ComandsHandler;
            client.Log += Log;

            var token = "Твій токен";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task ComandsHandler(SocketMessage msg)
        {   
            if(!msg.Author.IsBot)
                msg.Channel.SendMessageAsync(msg.Content);
            return Task.CompletedTask;
        }
    }
}