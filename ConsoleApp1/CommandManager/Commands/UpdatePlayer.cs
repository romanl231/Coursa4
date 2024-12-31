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
    class UpdatePlayer : ICommand
    {
        public PlayerService PlayerService { get; set; }
        public UpdatePlayer(DBContext dbContext)
        {
            PlayerService = new PlayerService(dbContext);
        }

        public void Execute()
        {
            Console.WriteLine("Enter info about new player.");
            Console.WriteLine("Enter new player name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new player password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter new player game type:");
            string gameType = Console.ReadLine();
            try
            {
                PlayerService.Update(UserSession.CurrentUser.Id, name, password);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetDescription() => "Update player info.";
    }
}
