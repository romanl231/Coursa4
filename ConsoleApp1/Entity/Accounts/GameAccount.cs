using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab2.DbContext;
using lab2.Entity.Games;

namespace lab2.Entity.Accounts
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        private int rating = 1;
        public virtual int CurrentRating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value < 1 ? 1 : value;

            }
        }
        public int GamesCount { get; set; }

        public string Password { get; set; }
        private static Random random = new Random();

        public GameAccount(int id, string uname, string password)
        {
            Id = id;
            UserName = uname;
            CurrentRating = 10;
            Password = password;
        }

        public virtual void WinGame(Game g)
        {
            CurrentRating += g.Rating;
            GamesCount++;
        }

        public virtual void LoseGame(Game g)
        {
            CurrentRating -= g.Rating;
            GamesCount++;
        }
    }
}