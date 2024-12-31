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
    class LogAsAdmin : ICommand
    {
        public PlayerService PlayerService { get; set; }
        public LogAsAdmin(DBContext dbContext)
        {
            PlayerService = new PlayerService(dbContext);
        }

        public void Execute()
        {
            Console.WriteLine("Enter admin password:");
            string password = Console.ReadLine();
            if(password == UserSession.CurrPass)
            {
                UserSession.SetUserRole(UserSession.UserRole.Admin);
            }
            else
            {
                Console.WriteLine("Wrong password");
            }
        }

        public string GetDescription() => "Log as admin";
    }
}
