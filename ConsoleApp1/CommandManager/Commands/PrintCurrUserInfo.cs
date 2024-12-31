using lab2.CommandManager.Interfaces;
using lab2.Data;
using lab2.DbContext;
using lab2.ServiceLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab2.CommandManager.Commands
{
    class PrintCurrUserInfo : ICommand
    {

        public PlayerService PlayerService { get; set; }
        public PrintCurrUserInfo(DBContext dbContext)
        {
            PlayerService = new PlayerService(dbContext);
        }

        public void Execute()
        {
            Console.WriteLine($"{UserSession.CurrentUser.Id,-10}\t{UserSession.CurrentUser.UserName,-10}" +
                   $"\t{UserSession.CurrentUser.CurrentRating,-10}\t{UserSession.CurrentUser.GamesCount,-10}");
        }
        public string GetDescription() => "Print current user stats";
    }
}
