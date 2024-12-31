using System.Data;
using System;
using lab2.CommandManager.Commands;
using lab2.CommandManager;
using lab2.DbContext;
using lab2.Entity.Accounts;
using lab2.Entity.Games;


namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext dbContext = new DBContext(new List<GameAccount>(), new List<Game>());
            CommandManager commandManager = new CommandManager();
            commandManager.RegisterCommand("register", new CreatePlayer(dbContext));
            commandManager.RegisterCommand("play", new PlayGame(dbContext));
            commandManager.RegisterCommand("login", new Login(dbContext));
            commandManager.RegisterCommand("update_info", new UpdatePlayer(dbContext));
            commandManager.RegisterCommand("logout", new Logout(dbContext));
            commandManager.RegisterCommand("admin", new LogAsAdmin(dbContext));
            commandManager.RegisterCommand("print_stats", new PrintCurrUserInfo(dbContext));
            commandManager.RegisterCommand("print_all_players", new PrintAllPlayers(dbContext));
            commandManager.RegisterCommand("print_all_games", new PrintAllGames(dbContext));
            commandManager.RegisterCommand("exit", new ExitProgram(dbContext));
            commandManager.RegisterCommand("show_player_games", new FindGamesForPlayer(dbContext));
            while (true)
            {
                Console.WriteLine();
                    commandManager.ShowCommands();
                    Console.Write("Input command: ");
                    var command = Console.ReadLine();
                    commandManager.ExecuteCommand(command ?? "");
            }
        }
    }
}
