using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using lab2.Entity.Games;

namespace lab2.Entity.Accounts
{
    class WinStreakAccount : GameAccount
    {
        private int winStreakCnt;

        private int WinStreakCnt
        {
            get { return winStreakCnt; }
            set
            {
                if (value > 10)
                    winStreakCnt = 10;
                else
                    winStreakCnt = value;
            }
        }

        public WinStreakAccount(int id, string userName, string password) : base(id, userName, password)
        {
            winStreakCnt = 0;
        }

        public override void WinGame(Game g)
        {
            WinStreakCnt++;
            if (g.Rating != 0)
            {
                CurrentRating += g.Rating + WinStreakCnt - 1;
                Console.WriteLine($"Win streak bonus rating: {WinStreakCnt - 1}");
            }
            GamesCount++;
        }


        public override void LoseGame(Game g)
        {
            WinStreakCnt = 0;
            if (g.Rating != 0)
            {
                CurrentRating -= g.Rating;
            }
            GamesCount++;
        }

    }
}
