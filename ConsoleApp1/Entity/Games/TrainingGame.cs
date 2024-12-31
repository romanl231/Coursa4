using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Entity.Accounts;

namespace lab2.Entity.Games
{
    public class TrainingGame : Game
    {
        public TrainingGame(int gameIndex, GameAccount opponentName1, GameAccount opponentName2, GameAccount winner, int rating)
        : base(gameIndex, opponentName1, opponentName2, winner, rating)
        {
        }

        public override int RateGenerator()
        {
            return 0;
        }
    }
}
