using lab2.CommandManager.Interfaces;
using lab2.Data;
using lab2.DbContext;
using lab2.ServiceLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.CommandManager.Commands
{
    class PrintAllPlayers : ICommand
    {

        public PlayerService PlayerService { get; set; }
        public PrintAllPlayers(DBContext dbContext)
        {
            PlayerService = new PlayerService(dbContext);
        }

        public void Execute()
        {
            var players = PlayerService.GetAll();

            Console.WriteLine("PlayerId\tUserName\tRating\tGames count");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Id,-10}\t{player.UserName,-10}" +
                    $"\t{player.CurrentRating,-10}\t{player.GamesCount,-10}");
            }
        }

        public string GetDescription() => "Print all players";

    }
}
