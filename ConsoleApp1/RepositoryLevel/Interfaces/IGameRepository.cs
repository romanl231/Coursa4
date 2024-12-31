using lab2.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.RepositoryLevel.Interfaces
{
    public interface IGameRepository
    {
        void Create(Game game);
        Game ReadByID(int id);
        List<Game> ReadAll();
        void Update(int id, Game game);
        void Delete(Game game);
    }
}
