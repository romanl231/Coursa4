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
    class PlayGame : ICommand
    {

        public GameService GameService { get; set; }
        public PlayGame(DBContext dbContext)
        {
            GameService = new GameService(dbContext);
        }

        public void Execute()
            {
                Console.WriteLine("Input game type name:");
                string gameType = Console.ReadLine();
                try
                {
                    GameService.CreateNew(gameType);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public string GetDescription() => "Play new game";

        }
    }

