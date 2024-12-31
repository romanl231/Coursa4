using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.CommandManager.Interfaces;
using lab2.Data;
using lab2.DbContext;
using lab2.ServiceLevel;

namespace lab2.CommandManager.Commands
{
    class Login : ICommand
    {

        public PlayerService PlayerService { get; set; }
        public Login(DBContext dbContext)
        {
            PlayerService = new PlayerService(dbContext);
        }

        public void Execute()
        {
            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();
            try
            {
                PlayerService.Login(username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetDescription() => "Login";
    }
}
