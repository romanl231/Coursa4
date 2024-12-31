using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using lab2.CommandManager.Interfaces;
using lab2.Data;
using lab2.DbContext;
using lab2.ServiceLevel;

namespace lab2.CommandManager.Commands
{
    class PrintAllGames : ICommand
    {

        public GameService GameService { get; set; }
        public PrintAllGames(DBContext dbContext)
        {
            GameService = new GameService(dbContext);
        }

        public void Execute()
        {
            var games = GameService.GetAll();
            Console.WriteLine("GameId\tPlayer1\tPlayer2\tWinner\tRating");
            foreach (var game in games) 
            {
                Console.WriteLine($"{game.GameIndex,-10}\t {game.User1.UserName,-10}\t {game.User2.UserName,-10}\t {game.WinAccount.UserName,-10}\t {game.Rating}");
            }
        }

        public string GetDescription() => "Print all games.";
    }
}
