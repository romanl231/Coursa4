using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using lab2.CommandManager.Commands;
using lab2.DbContext;
using lab2.Entity.Accounts;
using lab2.Entity.Games;
using lab2.Factories;
using lab2.RepositoryLevel;
using lab2.ServiceLevel;
using lab2.ServiceLevel.Interfaces;



namespace lab2.Data
{
    internal class GameManager
    {
        private static Random random = new Random();
        private static GameAccount _bot;
    
        public GameManager()
        {
            _bot = PlayerFactory.CreatePlayer(0, "BOT", "1", "standart");
        }

        public bool Play(string gameType)
        {
            char[,] board = new char[3, 3]; // створюємо поле 
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = ' ';

            GameAccount player = UserSession.CurrentUser;
            GameAccount opponent = _bot;
            char currentPlayer = 'X';
            bool gameWon = false;

            while (!gameWon && !IsBoardFull(board))
            {
                PrintBoard(board);
                if (currentPlayer == 'X')
                {
                    bool validMove = false;
                    while (!validMove)
                    {
                        Console.WriteLine("Your turn\nInput row number (0-2) and column number (0-2), put space between:");
                        string[] input = Console.ReadLine().Split(' ');

                        if (input.Length == 2 && int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col) && row >= 0 && row < 3 && col >= 0 && col < 3)
                        {
                            if (board[row, col] == ' ')
                            {
                                board[row, col] = 'X';
                                currentPlayer = 'O';
                                validMove = true;
                            }
                            else
                            {
                                Console.WriteLine("It's cage is used");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Uncorrect turn, try again");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bot turn...");
                    bool moved = false;
                    while (!moved)
                    {
                        int row = random.Next(3);
                        int col = random.Next(3);
                        if (board[row, col] == ' ')
                        {
                            board[row, col] = 'O';
                            moved = true;
                            currentPlayer = 'X';
                        }
                    }
                }

                gameWon = CheckWin(board);
            }

            PrintBoard(board);

            if (gameWon)
            {
                if (currentPlayer == 'O')
                {
                    Console.WriteLine("You win!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Bot win!");
                    //Game game = GameFactory.CreateGame(gameType, _gameIndex, player, opponent, opponent, 0);
                    //_serviceGames.CreateNew(game);
                    //_gameIndex++;
                    //player.User.LoseGame(game);
                    //opponent.User.WinGame(game);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Draw!");
                return Play(gameType);
            }
        }

        private void PrintBoard(char[,] board)
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("  -----");
            }
        }

        private bool IsBoardFull(char[,] board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j] == ' ')
                        return false;
            return true;
        }

        private bool CheckWin(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;
                if (board[0, i] != ' ' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }


        /* Command */
        

    }
}
