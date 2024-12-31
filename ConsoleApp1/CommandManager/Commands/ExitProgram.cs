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
    class ExitProgram : ICommand
    {
        public PlayerService PlayerService { get; set; }
        public ExitProgram(DBContext dbContext)
        {
            PlayerService = new PlayerService(dbContext);
        }

        public void Execute()
        {
            Environment.Exit(0);
        }

        public string GetDescription() => "Exit program";
    }
}
