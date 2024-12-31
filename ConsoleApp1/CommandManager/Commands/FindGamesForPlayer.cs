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
    class FindGamesForPlayer : ICommand
    {
        public GameService GameService { get; set; }
        public FindGamesForPlayer(DBContext dbContext)
        {
            GameService = new GameService(dbContext);
        }

        public void Execute()
        {
            try
            {
                var games = GameService.ShowGamesForPlayer(UserSession.CurrentUser);
                Console.WriteLine("GameId\tPlayer1\tPlayer2\tWinner\tRating");
                foreach (var game in games)
                {
                    Console.WriteLine($"{game.GameIndex,-10}\t {game.User1.UserName,-10}\t {game.User2.UserName,-10}\t {game.WinAccount.UserName,-10}\t {game.Rating}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetDescription() => "Find games for player.";
    }
}
