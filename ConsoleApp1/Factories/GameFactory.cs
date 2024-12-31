using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1;
using lab2.Entity.Games;
using lab2.Entity.Accounts;

namespace lab2.Factories
{
    public static class GameFactory
    {

        public static Game CreateGame(string gameType, int gameIndex, GameAccount opponentName1, GameAccount opponentName2, GameAccount winner, int rating)
        {

            switch (gameType.ToLower())
            {
                case "standart":
                    return new StandartGame(gameIndex, opponentName1, opponentName2, winner, 0);
                case "training":
                    return new TrainingGame(gameIndex, opponentName1, opponentName2, winner, 0);
                default:
                    throw new Exception("Invalid game type");
            }
        }
    }
}
