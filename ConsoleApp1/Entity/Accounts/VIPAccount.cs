using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Entity.Games;

namespace lab2.Entity.Accounts
{
    class VIPAccount : GameAccount
    {
        Random random = new Random();
        public VIPAccount(int id, string userName, string password) : base(id,userName, password) { }

        public override void WinGame(Game g)
        {
            if (g.Rating != 0)
            {
                int bonus = random.Next(1, 6);
                Console.WriteLine($"VIP bonus rating: {bonus}");
                CurrentRating += g.Rating + bonus;
            }
            GamesCount++;
        }

        public override void LoseGame(Game g)
        {
            if (g.Rating != 0)
            {
                int bonus = random.Next(1, 6);
                Console.WriteLine($"Rating after VIP bonus: {bonus}");
                CurrentRating -= g.Rating + random.Next(1, 6);
            }
            GamesCount++;
        }

    }



}

