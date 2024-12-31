using lab2.Entity.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.RepositoryLevel.Interfaces
{
    public interface IPlayerRepository
    {
        void Create(GameAccount player);
        GameAccount FindUserByName(string name);
        GameAccount ReadById(int id);
        List<GameAccount> ReadAll();
        void Update(int id, string username, string password);
        void Delete(GameAccount player);
    }
}
