using lab2.Entity.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.ServiceLevel.Interfaces
{
    public interface IPlayerService
    {
        bool CheckForExisting(string username);
        void CreateNew(string username, string password, string accType);
        bool Login(string username, string password);
        GameAccount GetUserById(int id);
        List<GameAccount> GetAll();
        void Update(int id, string username, string password);
        void Delete(int id);
    }
}
