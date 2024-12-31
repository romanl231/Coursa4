using lab2.Entity.Accounts;
using lab2.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.ServiceLevel.Interfaces
{
    public interface IGameService
    {
        void CreateNew(string gameType);
        Game GetById(int id);
        List<Game> GetAll();
        void Delete(int id);
        List<Game> ShowGamesForPlayer(GameAccount player);
    }
}
