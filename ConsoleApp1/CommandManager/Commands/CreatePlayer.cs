using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using lab2.CommandManager.Interfaces;
using lab2.Data;
using lab2.DbContext;
using lab2.ServiceLevel;

namespace lab2.CommandManager.Commands
{
    class CreatePlayer : ICommand
    {
        public PlayerService PlayerService { get; set; }
        public CreatePlayer(DBContext dbContext)
        {
            PlayerService = new PlayerService(dbContext);
        }

        public void Execute() {
            Console.WriteLine("Input player name:");
            string name = Console.ReadLine();
            Console.WriteLine("Input your password:");
            string password = (string) Console.ReadLine();
            Console.WriteLine("Repeat your password:");
            string confirmPassword = (string) Console.ReadLine();
            string accType;
            Console.WriteLine("Input account type:");
            accType = Console.ReadLine();
            

            if (confirmPassword != null && password != null && confirmPassword == password)
            {
                    try
                    {
                        PlayerService.CreateNew(name, password, accType);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
            }
            else
            {
                Console.WriteLine("Passwords doesn't match, try again");
                Execute();
            }
            
        }
        public string GetDescription() => "Create a new player.";

    }
}
