using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Entity;
using lab2.Entity.Accounts;

namespace lab2.Entity.Games
{
    public abstract class Game
    {
        private int rating = 0;
        Random random = new Random();
        public GameAccount User1 { get; set; }
        public GameAccount User2 { get; set; }
        public GameAccount WinAccount { get; set; }
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value < 0 ? 0 : value;
            }
        }
        public int GameIndex { get; set; }

        public Game(int gameIndex, GameAccount user1, GameAccount user2, GameAccount winer, int rating)
        {
            GameIndex = gameIndex;
            User1 = user1;
            User2 = user2;
            Rating = RateGenerator();
            WinAccount = winer;
        }

        public abstract int RateGenerator();
    }

}
