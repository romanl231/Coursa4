using System;
using lab2.Entity.Games;
using lab2.Entity.Accounts;

namespace lab2.DbContext
{
    public class DBContext
    {
        public List<GameAccount> Players { get; set; }
        public List<Game> Games { get; set; }

        public DBContext(List<GameAccount> players, List<Game> games)
        {
            Players = players ?? new List<GameAccount>();
            Games = games ?? new List<Game>();
        }
    }
}
