using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.Entity.Games;

namespace lab2.Entity.Accounts
{

    class StandartAccount : GameAccount
    {
        public StandartAccount(int id, string userName, string password) : base(id, userName, password) { }

        public override void WinGame(Game g)
        {
            base.WinGame(g);
        }

        public override void LoseGame(Game g)
        {
            base.LoseGame(g);
        }
    }
}
