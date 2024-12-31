using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.CommandManager.Interfaces;
using lab2.CommandManager.Commands;
using lab2.Data;

namespace lab2.CommandManager
{
    class CommandManager
    {
        public Dictionary<string, ICommand> commands = new();

        public void RegisterCommand(string commandName, ICommand command)
        {
            commands[commandName] = command;
        }
        public void ExecuteCommand(string command)
        {
            if (commands.ContainsKey(command))
            {
                if (UserSession.Role == UserSession.UserRole.Guest)
                {
                    if (command == "login" || command == "register" || command == "exit")
                    {
                        commands[command].Execute();
                    }
                    else Console.WriteLine("You can't use this command");
                }
                else if (UserSession.Role == UserSession.UserRole.User)
                 {
                    if (command == "logout" || command == "update_info" || command == "play" ||
                        command == "get_games_for_player" || command == "show_player_games" || command == "print_stats" || command == "admin")
                    {
                        commands[command].Execute();
                    }
                    else Console.WriteLine("You can't use this command");
                }
                else if (UserSession.Role == UserSession.UserRole.Admin)
                {
                    if (command == "logout" || command == "update_info" || command == "play" ||
                       command == "get_games_for_player" || command == "print_stats" || command == "show_player_games" || command == "admin"
                       || command == "print_all_players" || command == "print_all_games")
                    {
                        commands[command].Execute();
                    }
                }
            }
            else
            {
                Console.WriteLine("Command don't found!");
            }
        }

        public void ShowCommands()
        {
            Console.WriteLine("Available commands");
            foreach (var command in commands)
            {
                if (UserSession.Role == UserSession.UserRole.Guest)
                {
                    if (command.Key == "login" || command.Key == "register" || command.Key == "exit")
                        Console.WriteLine($"{command.Key}: {command.Value.GetDescription()}");
                }
                else if (UserSession.Role == UserSession.UserRole.User)
                {
                    if (command.Key == "logout" || command.Key == "update_info" || command.Key == "play" ||
                        command.Key == "get_games_for_player" || command.Key == "show_player_games" || command.Key == "print_stats" || command.Key == "admin")
                    {
                        Console.WriteLine($"{command.Key}: {command.Value.GetDescription()}");
                    }
                }
                else if (UserSession.Role == UserSession.UserRole.Admin)
                {
                    if (command.Key == "logout" || command.Key == "update_info" || command.Key == "play" ||
                       command.Key == "get_games_for_player" || command.Key == "show_player_games" || command.Key == "print_stats" || command.Key == "admin"
                       || command.Key == "print_all_players" || command.Key == "print_all_games")
                    {
                        Console.WriteLine($"{command.Key}: {command.Value.GetDescription()}");
                    }
    
                }
            }
        }
    }
}
